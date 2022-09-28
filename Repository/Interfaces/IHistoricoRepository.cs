using Processos.Entity;

namespace Processos.Repository.Interfaces
{
    public interface IHistoricoRepository : IBaseRepository<ProcessoHistorico, int>
    {
        IEnumerable<ProcessoHistorico> Get();
        IEnumerable<ProcessoHistorico> ProcessoId(int processoId);
        ProcessoHistorico GetById(int id);
    }
}
