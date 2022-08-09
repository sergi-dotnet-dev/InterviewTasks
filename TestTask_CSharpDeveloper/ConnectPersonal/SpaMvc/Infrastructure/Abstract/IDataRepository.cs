namespace SpaMvc.Infrastructure.Abstract
{
    public interface IDataRepository<T> where T : class
    {
        IQueryable<T> Data { get; }
    }
}
