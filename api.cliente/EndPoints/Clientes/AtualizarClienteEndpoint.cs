using core.cliente.DTOs;
using core.cliente.Interfaces;

namespace api.cliente.EndPoints.Clientes
{
    public class AtualizarClienteEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapPut("/atualizar/{id}", HandleAsync)
               .WithName("Clientes: Atualizar")
               .WithSummary("Atualiza um cliente")
               .WithDescription("Atualiza os dados de um cliente existente")
               .WithOrder(2);
        }

        private static async Task<IResult> HandleAsync(IClienteServico servico, AtualizarClienteRequest request, int id)
        {
            if (id != request.Id)
                return TypedResults.BadRequest();
                
            await servico.AtualizarAsync(request);
            return TypedResults.Ok();
        }

    }
}