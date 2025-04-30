using core.cliente.DTOs;
using core.cliente.Interfaces;

namespace api.cliente.EndPoints.Clientes
{
    public class CriarClienteEndpoint: IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapPost("/criar", HandleAsync)
               .WithName("Clientes: Criar")
               .WithSummary("Cria um cliente")
               .WithDescription("Cria um cliente com dados básicos")
               .WithOrder(1);
        }

        private static async Task<IResult> HandleAsync(IClienteServico servico, CriarClienteRequest request)
        {
            await servico.CriarAsync(request);
            return TypedResults.Created("/clientes", request);
        }

    }
}