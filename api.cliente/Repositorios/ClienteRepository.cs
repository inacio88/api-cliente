using api.cliente.Data;
using core.cliente.Entidades;
using core.cliente.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.cliente.Repositorios
{
    public class ClienteRepository(AppDbContext appDbContext) : IClienteRepository
    {
        public async Task CriarAsync(Cliente cliente)
        {
            appDbContext.Clientes.Add(cliente);
            await appDbContext.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Cliente cliente)
        {
            var existente = await appDbContext.Clientes.FindAsync(cliente.Id);
            if (existente is null)
                throw new InvalidOperationException("Cliente não encontrado.");

            existente.Nome = cliente.Nome;
            existente.Email = cliente.Email;
            existente.CPF = cliente.CPF;
            existente.RG = cliente.RG;

            appDbContext.Clientes.Update(existente);
            await appDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Cliente>> ListarTodosAsync()
        {
            return await appDbContext.Clientes
                .Include(c => c.Contatos)
                .Include(c => c.Enderecos)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Cliente?> ObterPorIdAsync(int id)
        {
            return await appDbContext.Clientes
                .Include(c => c.Contatos)
                .Include(c => c.Enderecos)
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task RemoverAsync(int id)
        {
            var cliente = await appDbContext.Clientes.FindAsync(id);
            if (cliente is null)
                throw new InvalidOperationException("Cliente não encontrado.");

            appDbContext.Clientes.Remove(cliente);
            await appDbContext.SaveChangesAsync();
        }
    }
}
