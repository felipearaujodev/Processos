using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace Processos.Models.Request
{
    public class ProcessoParteRequest
    {
        [Required]
        public int ProcessoId { get; set; }
        [Required(ErrorMessage = "Sigiloso é obrigatório")]
        public bool Sigiloso { get; set; }
        public string? Cpf { get; set; }
        public string? Nome { get; set; }
        [RegularExpression("masculino|feminino|ignorado", ErrorMessage = "Sexo deve ser masculino | feminino | ignorado")]
        public string? Sexo { get; set; }
    }
}
