namespace Processos.Models.Request
{
    public class ProcessoParteRequest
    {
        public int ProcessoId { get; set; }
        public bool Sigiloso { get; set; }
        public string? Cpf { get; set; }
        public string? Nome { get; set; }
        public string? Sexo { get; set; }
    }
}
