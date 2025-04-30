using api.cliente.Data;
using core.cliente.DTOs;
using core.cliente.Entidades;
using core.cliente.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.cliente.Repositorios
{
    public class ClienteRepository(AppDbContext appDbContext) : IClienteRepository
    {
        public async Task CriarAsync(Cliente cliente)
        {
            await appDbContext.Clientes.AddAsync(cliente);
            await appDbContext.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Cliente cliente)
        {
            var existente = await appDbContext.Clientes
                .Include(c => c.Contatos)
                .Include(c => c.Enderecos)
                .FirstOrDefaultAsync(c => c.Id == cliente.Id);

            if (existente is null)
                throw new InvalidOperationException("Cliente não encontrado.");

            existente.Nome = cliente.Nome;
            existente.Email = cliente.Email;
            existente.CPF = cliente.CPF;
            existente.RG = cliente.RG;

            appDbContext.Contatos.RemoveRange(existente.Contatos);
            await appDbContext.Contatos.AddRangeAsync(cliente.Contatos);

            appDbContext.Enderecos.RemoveRange(existente.Enderecos);
            await appDbContext.Enderecos.AddRangeAsync(cliente.Enderecos);

            await appDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Cliente>> ListarTodosAsync(FiltrarClientesRequest filtro)
        {
            var query = appDbContext.Clientes
                .Include(c => c.Contatos)
                .Include(c => c.Enderecos)
                .AsNoTracking();

            if (!string.IsNullOrEmpty(filtro.Nome))
            {
                query = query.Where(c => c.Nome.Contains(filtro.Nome));
            }

            if (!string.IsNullOrEmpty(filtro.Email))
            {
                query = query.Where(c => c.Email.Contains(filtro.Email));
            }

            if (!string.IsNullOrEmpty(filtro.CPF))
            {
                query = query.Where(c => c.CPF.Contains(filtro.CPF));
            }

            return await query.ToListAsync();
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
