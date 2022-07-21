#region Task
//Есть "сервер" в виде статического класса.  
//У него есть переменная count (тип int) и два метода, которые позволяют эту переменную читать и писать: GetCount() и AddToCount(int value). 
//К серверу стучатся множество параллельных клиентов, которые в основном читают, но некоторые добавляют значение к count. 

//Нужно реализовать GetCount / AddToCount так, чтобы: 
//читатели могли читать параллельно, без выстраивания в очередь по локу;
//писатели писали только последовательно и никогда одновременно;
//пока писатели добавляют и пишут, читатели должны ждать окончания записи. 

#endregion
/// <summary>
/// Для реализации поставленной задачи идеально подходит класс ReaderWriterLockSlim, обеспечивающий защиту ресурса и
/// предоставляющий ограниченный доступ к нему
/// </summary>
public static class ServerImitator
{
    private static Int32 Count = default;
    private static readonly RWLock @lock = new();

    public static Int32 GetCount()
    {
        using (@lock.ReadLock())
            return Count;
    }
    public static void AddToCount(Int32 value)
    {
        using (@lock.WriteLock())
            Count += value;
    }
}
#region "Адаптер" использования ReaderWriterLockSlim
/// <summary>
/// Вспомогательный класс использования ReaderWriteLockSlim
/// Синтаксический сахар для using(ReadWriteLockSlim){}
/// </summary>
public class RWLock : IDisposable
{
    /// <summary>
    /// Прослойка для многопотокового паралелльного доступа к чтению данных
    /// </summary>
    public class ReadLockLayer : IDisposable
    {
        private readonly ReaderWriterLockSlim _lock;
        public ReadLockLayer(ReaderWriterLockSlim @lock)
        {
            _lock = @lock;
            _lock.EnterReadLock();
        }
        public void Dispose()
            => _lock.ExitReadLock();
    }
    /// <summary>
    /// Прослойка для однопотокового доступа к записи данных и монопольного владения блокировкой данных
    /// </summary>
    public class WriteLockLayer : IDisposable
    {
        private readonly ReaderWriterLockSlim _lock;
        public WriteLockLayer(ReaderWriterLockSlim @lock)
        {
            _lock = @lock;
            _lock.EnterWriteLock();
        }
        public void Dispose()
            => _lock.ExitWriteLock();
    }
    private readonly ReaderWriterLockSlim Lock = new();
    public ReadLockLayer ReadLock()
        => new(Lock);
    public WriteLockLayer WriteLock()
        => new(Lock);
    public void Dispose()
        => Lock.Dispose();
}
#endregion