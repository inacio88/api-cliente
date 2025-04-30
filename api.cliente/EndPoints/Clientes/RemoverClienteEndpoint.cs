using core.cliente.DTOs;
using core.cliente.Interfaces;

namespace api.cliente.EndPoints.Clientes
{
    public class RemoverClienteEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapDelete("/remover/{id}", HandleAsync)
               .WithName("Clientes: Remover")
               .WithSummary("Remove um cliente")
               .WithDescription("Remove um cliente pelo ID")
               .WithOrder(3);
        }

        private static async Task<IResult> HandleAsync(IClienteServico servico, int id)
        {
            var request = new RemoverClienteRequest { Id = id };
            await servico.RemoverAsync(request);
            return TypedResults.NoContent();
        }

    }
}