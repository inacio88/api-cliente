namespace core.cliente.DTOs
{
    public class AtualizarEnderecoRequest
    {
        public int Id { get; set; }

        public string Tipo { get; set; } = string.Empty;

        public string CEP { get; set; } = string.Empty;

        public string Logradouro { get; set; } = string.Empty;

        public int Numero { get; set; }

        public string Bairro { get; set; } = string.Empty;

        public string Complemento { get; set; } = string.Empty;

        public string Cidade { get; set; } = string.Empty;

        public string Estado { get; set; } = string.Empty;

        public string Referencia { get; set; } = string.Empty;
    }
}