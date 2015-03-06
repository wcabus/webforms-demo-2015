namespace Munchies.Data.Repositories
{
    public interface IWriterRepository<in T> where T : class, new()
    {
        void Save(T entity);
        void Remove(T entity);
        void SaveChanges();
    }
}