
using Processos.Entity;

namespace Processos.Repository.Interfaces
{
    public interface IProcessoRepository : IBaseRepository
    {
        IEnumerable<Processo> Get();
        Processo Get(int id);
    }
}
