using Microsoft.EntityFrameworkCore;
using Processos.Context;
using Processos.Entity;
using Processos.Repository.Interfaces;

namespace Processos.Repository
{
    public class HistoricoRepository : BaseRepository, IHistoricoRepository
    {
        private readonly ProcessoContext _context;

        public HistoricoRepository(ProcessoContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<ProcessoHistorico> Get() => _context.ProcessoHistorico.Include(p => p.Partes).ToList();

        public ProcessoHistorico GetById(int id)
        {
            return _context.ProcessoHistorico.Include(p => p.Partes).Where(p => p.Id == id).FirstOrDefault();
        }
    }
}
