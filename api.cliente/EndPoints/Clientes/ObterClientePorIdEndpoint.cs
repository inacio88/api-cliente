using core.cliente.DTOs;
using core.cliente.Interfaces;

namespace api.cliente.EndPoints.Clientes
{
    public class ObterClientePorIdEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapGet("/listar/{id}", HandleAsync)
               .WithName("Clientes: Obter por ID")
               .WithSummary("Obtém cliente por ID")
               .WithDescription("Obtém um cliente pelo ID fornecido")
               .WithOrder(4);
        }

        private static async Task<IResult> HandleAsync(IClienteServico servico, int id)
        {
            var result = await servico.ObterPorIdAsync(new ObterClientePorIdRequest { Id = id });
            return result is not null ? TypedResults.Ok(result) : TypedResults.NotFound();
        }

    }
}