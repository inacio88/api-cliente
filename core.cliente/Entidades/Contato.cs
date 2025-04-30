using System.ComponentModel.DataAnnotations;
namespace core.cliente.Entidades;

public class Contato
{
    public int Id { get; set; }
    public int IdCliente { get; set; }
    private string _tipo;
    [Required]
    public string Tipo
    {
        get => _tipo;
        set
        {
            string[] tiposValidos = { "Residencial", "Comercial", "Celular" };
            if (Array.IndexOf(tiposValidos, value) == -1)
                throw new ArgumentException("Tipo inválido. Deve ser Residencial, Comercial ou Celular.");
            _tipo = value;
        }
    }

    [Range(10, 99, ErrorMessage = "DDD inválido.")]
    public int DDD { get; set; }

    [Required]
    public decimal Telefone { get; set; }
}