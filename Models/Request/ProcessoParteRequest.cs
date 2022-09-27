using Microsoft.Build.Framework;

namespace Processos.Models.Request
{
    public class ProcessoParteRequest
    {
        [Required]
        public int ProcessoId { get; set; }
        [Required]
        public bool Sigiloso { get; set; }
        public string? Cpf { get; set; }
        public string? Nome { get; set; }
        public string? Sexo { get; set; }
    }
}
