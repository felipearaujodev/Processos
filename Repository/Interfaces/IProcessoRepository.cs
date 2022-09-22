
using Processos.Entity;

namespace Processos.Repository.Interfaces
{
    public interface IProcessoRepository : IBaseRepository
    {
        IEnumerable<Processo> Get();
        Processo GetById(int id);
    }
}
