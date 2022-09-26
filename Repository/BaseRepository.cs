using Microsoft.EntityFrameworkCore;
using Processos.Context;
using Processos.Repository.Interfaces;

namespace Processos.Repository
{
    public class BaseRepository : IBaseRepository
    {
        private readonly ProcessoContext _context;

        public BaseRepository(ProcessoContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void Delete<T>(T entity) where T : class
        {
            var ent = _context.Set<T>().Find(entity);

            if (ent != null)
            {
                _context.Set<T>().Remove(entity);
            }
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
