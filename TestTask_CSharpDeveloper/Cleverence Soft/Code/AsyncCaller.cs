#region Task
//Нужно реализовать возможность полусинхронного вызова делегата (написать реализацию класса AsyncCaller), который бы работал таким образом: 

//EventHandler h = new EventHandler(this.myEventHandler);
//ac = new AsyncCaller(h);
//bool completedOK = ac.Invoke(5000, null, EventArgs.Empty);

//"Полусинхронного" в данном случае означает, что делегат будет вызван, и вызывающий поток будет ждать, пока вызов не выполнится.
//Но если выполнение делегата займет больше 5000 миллисекунд, то ac.Invoke выйдет и вернет в completedOK значение false.
#endregion

/// <summary>
/// Для выполнения поставленной задачи воспользовался bool Task.Wait(Int32 param),
/// передавая время псевдоработы делегата как Thread.Sleep(Int32 param)
/// </summary>
public sealed class AsyncCaller
{
    private EventHandler _eventHandler;

    public AsyncCaller(EventHandler eventHandler)
        => _eventHandler = eventHandler;

    public bool Invoke(Int32 timeoutInMillieSeconds, object obj, EventArgs args)
    {
        if (timeoutInMillieSeconds <= 0)
            throw new ArgumentException("Timeout can not be negative or zero");

        var task = Task.Factory
            .StartNew(() => _eventHandler.Invoke(obj, args));

        return task
            .Wait(timeoutInMillieSeconds);
    }
}