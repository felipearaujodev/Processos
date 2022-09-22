using Processos.Entity;
using Microsoft.EntityFrameworkCore;

namespace Processos.Context
{
    public class ProcessoContext : DbContext
    {
        public ProcessoContext(DbContextOptions<ProcessoContext> options) : base(options)
        { }
        public DbSet<Processo> Processos { get; set; }
        public DbSet<ProcessoHistorico> ProcessoHistorico { get; set; }
        
    }
}
