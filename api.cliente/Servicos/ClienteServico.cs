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
                RG = request.RG
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
                RG = request.RG
            };

            await clienteRepository.AtualizarAsync(cliente);
        }

        public async Task<IEnumerable<Cliente>> ListarTodosAsync()
        {
            return await clienteRepository.ListarTodosAsync();
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
