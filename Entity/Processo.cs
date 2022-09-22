namespace Processos.Entity
{
    public class Processo
    {
        public int Numero { get; set; }
        DateTime Data { get; set; }
        public string? Tipo { get; set; }
        public bool Partes { get; set; }
        public string? Observacoes { get; set; }
        public string? Documentos { get; set; }
    }
}
