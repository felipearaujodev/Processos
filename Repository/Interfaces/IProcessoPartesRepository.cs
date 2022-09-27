using Processos.Entity;

namespace Processos.Repository.Interfaces
{
    public interface IProcessoPartesRepository : IBaseRepository
    {
        IEnumerable<ProcessoParte> Get();
        IEnumerable<ProcessoParte> GetProcessoId(int processoId);
        ProcessoParte GetById(int id);
    }
}
