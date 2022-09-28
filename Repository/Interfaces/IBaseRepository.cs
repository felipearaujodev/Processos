namespace Processos.Repository.Interfaces
{
    public interface IBaseRepository<TEntity, TKey> where TEntity : class
    {
        public void Add(TEntity entity);
        public void Update(TEntity entity);
        public void Delete(TKey id);
    }
}
