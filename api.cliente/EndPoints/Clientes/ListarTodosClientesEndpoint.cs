using core.cliente.Interfaces;

namespace api.cliente.EndPoints.Clientes
{
    public class ListarTodosClientesEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapGet("/listar", HandleAsync)
               .WithName("Clientes: Listar todos")
               .WithSummary("Lista todos os clientes")
               .WithDescription("Retorna uma lista de todos os clientes cadastrados")
               .WithOrder(5);
        }

        private static async Task<IResult> HandleAsync(IClienteServico servico)
        {
            var clientes = await servico.ListarTodosAsync();
            return TypedResults.Ok(clientes);
        }

    }
}