using Processos.Entity;

namespace Processos.Repository.Interfaces
{
    public interface IHistoricoRepository : IBaseRepository
    {
        IEnumerable<ProcessoHistorico> Get();
        ProcessoHistorico GetById(int id);
    }
}
