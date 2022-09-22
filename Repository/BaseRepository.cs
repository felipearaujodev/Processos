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
            throw new NotImplementedException();
        }

        public Task<bool> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public void Update<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }
    }
}
