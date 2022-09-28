using Microsoft.EntityFrameworkCore;
using Processos.Context;
using Processos.Entity;
using Processos.Repository.Interfaces;

namespace Processos.Repository
{
    public class ProcessoRepository : BaseRepository<Processo, int>, IProcessoRepository
    {
        private readonly ProcessoContext _context;

        public ProcessoRepository(ProcessoContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Processo> Get() => _context.Processos.Include(p=>p.Partes).ToList();

        public Processo GetById(int id)
        {
            return _context.Processos.Include(p => p.Partes).Where(p => p.Id == id).FirstOrDefault();
        }
    }
}
