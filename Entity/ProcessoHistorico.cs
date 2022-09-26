using System.ComponentModel.DataAnnotations;

namespace Processos.Entity
{
    public class ProcessoHistorico
    {
        
        [Key]
        public int Id { get; set; }
        public int ProcessoId { get; set; }
        public string? Numero { get; set; }
        public DateTime Data { get; set; }
        public DateTime DataLog { get; set; }
        public bool Restaurado { get; set; }
        public string? Tipo { get; set; }
        public IEnumerable<ProcessoParte>? Partes { get; set; }
        public string? Observacoes { get; set; }
        public string? DocumentoNome { get; set; }
        public string? Documento { get; set; }
    }
}
