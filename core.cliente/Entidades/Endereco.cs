namespace core.cliente.Entidades;

using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

public class Endereco
{
    public int Id { get; set; }
    public int IdCliente { get; set; }
    private string _tipo = string.Empty;
    [Required]
    public string Tipo
    {
        get => _tipo;
        set
        {
            string[] tiposValidos = { "Preferencial", "Entrega", "Cobrança" };
            if (Array.IndexOf(tiposValidos, value) == -1)
                throw new ArgumentException("Tipo inválido. Deve ser Preferencial, Entrega ou Cobrança.");
            _tipo = value;
        }
    }

    private string _cep = string.Empty;
    [Required]
    public string CEP
    {
        get => _cep;
        set
        {
            if (!Regex.IsMatch(value ?? "", @"^\d{5}-\d{3}$"))
                throw new ArgumentException("CEP inválido. Formato esperado: 00000-000.");
            _cep = value ?? string.Empty;
        }
    }

    [Required]
    public string Logradouro { get; set; } = string.Empty;

    [Required]
    public int Numero { get; set; }

    [Required]
    public string Bairro { get; set; } = string.Empty;

    public string Complemento { get; set; } = string.Empty;

    [Required]
    public string Cidade { get; set; } = string.Empty;

    [Required]
    public string Estado { get; set; } = string.Empty;

    public string Referencia { get; set; } = string.Empty;
}