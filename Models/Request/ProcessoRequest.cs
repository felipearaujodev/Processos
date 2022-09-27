using Processos.Entity;
using System.ComponentModel.DataAnnotations;

namespace Processos.Models.Request
{
    public class ProcessoRequest
    {

        //[Required(ErrorMessage = "Número é obrigatório")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Aceita apenas números inteiros")]
        public string? Numero { get; set; }
        [Required(ErrorMessage = "Data é obrigatório")]
        public DateTime Data { get; set; }
        [Required(ErrorMessage = "Tipo é obrigatório")]
        [RegularExpression("judicial|extrajudicial", ErrorMessage = "Tipo deve ser Judicial ou Extra judicial")]
        public string? Tipo { get; set; }
        public IEnumerable<ProcessoParte>? Partes { get; set; }
        
        public string? Observacoes { get; set; }

        [Required(ErrorMessage = "Nome do documento é obrigatório")]
        public string? DocumentoNome { get; set; }

        [Required(ErrorMessage = "Documento é obrigatório")]
        public string? Documento { get; set; }
    }
}
