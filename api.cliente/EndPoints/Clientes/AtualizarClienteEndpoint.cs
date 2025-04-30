using core.cliente.DTOs;
using core.cliente.Interfaces;

namespace api.cliente.EndPoints.Clientes
{
    public class AtualizarClienteEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapPut("", HandleAsync)
               .WithName("Clientes: Atualizar")
               .WithSummary("Atualiza um cliente")
               .WithDescription("Atualiza os dados de um cliente existente")
               .WithOrder(2);
        }

        private static async Task<IResult> HandleAsync(IClienteServico servico, AtualizarClienteRequest request)
        {
            await servico.AtualizarAsync(request);
            return TypedResults.Ok();
        }

    }
}