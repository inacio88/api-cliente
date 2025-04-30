namespace core.cliente.DTOs
{
    public class AtualizarClienteRequest
    {
        public int Id { get; set; }

        public string Nome { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string CPF { get; set; } = string.Empty;

        public string RG { get; set; } = string.Empty;
    }
}