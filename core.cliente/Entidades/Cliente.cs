using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using core.cliente.Validacao;

namespace core.cliente.Entidades
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        private string _email = string.Empty;
        [Required]
        [EmailAddress(ErrorMessage = "E-mail inválido.")]
        public string Email
        {
            get => _email;
            set
            {
                if (!new EmailAddressAttribute().IsValid(value))
                    throw new ArgumentException("E-mail inválido.");
                _email = value;
            }
        }

        private string _cpf = string.Empty;
        public string CPF
        {
            get => _cpf;
            set
            {
                if (!ValidaCPF(value))
                    throw new ArgumentException("CPF inválido.");
                _cpf = value;
            }
        }

        private string _rg = string.Empty;
        public string RG
        {
            get => _rg;
            set
            {
                if (!ValidaRG(value))
                    throw new ArgumentException("RG inválido.");
                _rg = value;
            }
        }

        private bool ValidaCPF(string cpf)
        {
            return ValidadorCPF.IsCpf(cpf);
        }

        private bool ValidaRG(string rg)
        {
            rg = Regex.Replace(rg ?? "", "[^0-9]", "");
            return rg.Length >= 7 && rg.Length <= 9;
        }
        public ICollection<Contato> Contatos { get; set; } = null!;
        public ICollection<Endereco> Enderecos { get; set; } = null!;
    }
}
