using api.cliente.EndPoints.Clientes;

namespace api.cliente.EndPoints
{
    public static class Endpoint
    {
        public static void MapEndpoints(this WebApplication app)
        {
            var endpoints = app.MapGroup("");


            endpoints.MapGroup("v1/cliente")
                .WithTags("Cliente")
                .MapEndpoint<CriarClienteEndpoint>()
                .MapEndpoint<AtualizarClienteEndpoint>()
                .MapEndpoint<ListarTodosClientesEndpoint>()
                .MapEndpoint<ObterClientePorIdEndpoint>()
                .MapEndpoint<RemoverClienteEndpoint>()
                ;
        }

        private static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder app) where TEndpoint : IEndpoint
        {
            TEndpoint.Map(app);
            return app;
        }

    }
}