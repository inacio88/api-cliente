namespace core.cliente.DTOs
{
    public class CriarContatoRequest
    {
        public int IdCliente { get; set; }

        public string Tipo { get; set; } = string.Empty;

        public int DDD { get; set; }

        public decimal Telefone { get; set; }
    }
}