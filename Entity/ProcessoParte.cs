using System.ComponentModel.DataAnnotations;

namespace Processos.Entity
{
    public class ProcessoParte
    {
        [Key]
        public int Id { get; set; }
        public int ProcessoId { get; set; }
        public bool Sigiloso { get; set; }
        public string? Cpf { get; set; }
        public string? Nome { get; set; }
        public string? Sexo { get; set; }
    }
}
