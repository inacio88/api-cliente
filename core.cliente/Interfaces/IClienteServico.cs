using core.cliente.DTOs;
using core.cliente.Entidades;

namespace core.cliente.Interfaces
{
    public interface IClienteServico
    {
        Task CriarAsync(CriarClienteRequest request);
        Task AtualizarAsync(AtualizarClienteRequest request);
        Task<IEnumerable<Cliente>> ListarTodosAsync(FiltrarClientesRequest request);
        Task<Cliente?> ObterPorIdAsync(ObterClientePorIdRequest request);
        Task RemoverAsync(RemoverClienteRequest request);
    }
}