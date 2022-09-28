
using Processos.Entity;

namespace Processos.Repository.Interfaces
{
    public interface IProcessoRepository : IBaseRepository<Processo, int>
    {
        IEnumerable<Processo> Get();
        Processo GetById(int id);
    }
}
