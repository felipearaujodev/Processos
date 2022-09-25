using System.ComponentModel.DataAnnotations;

namespace Processos.Entity
{
    public class Processo
    {
        [Key]
        public int Id { get; set; }
        public string? Numero { get; set; }
        public DateTime Data { get; set; }
        public string? Tipo { get; set; }
        public IEnumerable<ProcessoParte>? Partes { get; set; }
        public string? Observacoes { get; set; }
        public string? DocumentoNome { get; set; }
        public string? Documento { get; set; }
    }
}
