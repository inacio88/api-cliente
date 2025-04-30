using core.cliente.DTOs;
using core.cliente.Entidades;

namespace core.cliente.Interfaces
{
    public interface IClienteRepository
    {
        Task<Cliente?> ObterPorIdAsync(int id);
        Task<IEnumerable<Cliente>> ListarTodosAsync();
        Task CriarAsync(Cliente cliente);
        Task AtualizarAsync(Cliente cliente);
        Task RemoverAsync(int id);
    }
}