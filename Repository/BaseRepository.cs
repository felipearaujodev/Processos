using Microsoft.EntityFrameworkCore;
using Processos.Context;
using Processos.Repository.Interfaces;

namespace Processos.Repository
{
    public class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey> where TEntity : class
    {
        private readonly ProcessoContext _context;

        public BaseRepository(ProcessoContext context)
        {
            _context = context;
        }
        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
        }

        public void Delete(TKey id)
        {
            _context.Set<TEntity>().Remove(Select(id));
            _context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public TEntity Select(TKey id)
        {
            return _context.Set<TEntity>().Find(id);
        }
    }
}
