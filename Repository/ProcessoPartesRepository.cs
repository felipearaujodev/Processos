using Microsoft.EntityFrameworkCore;
using Processos.Context;
using Processos.Entity;
using Processos.Repository.Interfaces;

namespace Processos.Repository
{
    public class ProcessoPartesRepository : BaseRepository, IProcessoPartesRepository
    {
        private readonly ProcessoContext _context;

        public ProcessoPartesRepository(ProcessoContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<ProcessoParte> Get() => _context.ProcessoParte.ToList();


        public ProcessoParte GetById(int id)
        {
            return _context.ProcessoParte.Where(p => p.Id == id).FirstOrDefault();
        }

        public IEnumerable<ProcessoParte> GetProcessoId(int processoId)
        {
            return _context.ProcessoParte
            .Where(p => p.ProcessoId == processoId)
            .ToList();
        }
    }
}
