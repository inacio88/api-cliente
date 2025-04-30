using core.cliente.DTOs;
using core.cliente.Entidades;
using core.cliente.Interfaces;

namespace core.cliente.Servicos
{
    public class ClienteServico(IClienteRepository clienteRepository) : IClienteServico
    {
        public async Task CriarAsync(CriarClienteRequest request)
        {
            var cliente = new Cliente
            {
                Nome = request.Nome,
                Email = request.Email,
                CPF = request.CPF,
                RG = request.RG,
                Contatos = request.Contatos.Select(c => new Contato
                {
                    Tipo = c.Tipo,
                    DDD = c.DDD,
                    Telefone = c.Telefone
                }).ToList(),
                Enderecos = request.Enderecos.Select(e => new Endereco
                {
                    Tipo = e.Tipo,
                    CEP = e.CEP,
                    Logradouro = e.Logradouro,
                    Numero = e.Numero,
                    Bairro = e.Bairro,
                    Complemento = e.Complemento,
                    Cidade = e.Cidade,
                    Estado = e.Estado,
                    Referencia = e.Referencia
                }).ToList()
            };

            await clienteRepository.CriarAsync(cliente);
        }

        public async Task AtualizarAsync(AtualizarClienteRequest request)
        {
            var cliente = new Cliente
            {
                Id = request.Id,
                Nome = request.Nome,
                Email = request.Email,
                CPF = request.CPF,
                RG = request.RG,
                Contatos = request.Contatos.Select(c => new Contato
                {
                    IdCliente = request.Id,
                    Tipo = c.Tipo,
                    DDD = c.DDD,
                    Telefone = c.Telefone
                }).ToList(),
                Enderecos = request.Enderecos.Select(e => new Endereco
                {
                    IdCliente = request.Id,
                    Tipo = e.Tipo,
                    CEP = e.CEP,
                    Logradouro = e.Logradouro,
                    Numero = e.Numero,
                    Bairro = e.Bairro,
                    Complemento = e.Complemento,
                    Cidade = e.Cidade,
                    Estado = e.Estado,
                    Referencia = e.Referencia
                }).ToList()
            };

            await clienteRepository.AtualizarAsync(cliente);
        }

        public async Task<IEnumerable<Cliente>> ListarTodosAsync(FiltrarClientesRequest request)
        {
            return await clienteRepository.ListarTodosAsync(request);
        }

        public async Task<Cliente?> ObterPorIdAsync(ObterClientePorIdRequest request)
        {
            return await clienteRepository.ObterPorIdAsync(request.Id);
        }

        public async Task RemoverAsync(RemoverClienteRequest request)
        {
            await clienteRepository.RemoverAsync(request.Id);
        }
    }
}
