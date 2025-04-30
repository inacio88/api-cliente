using api.cliente.Data;
using api.cliente.EndPoints;
using api.cliente.Repositorios;
using core.cliente.Interfaces;
using core.cliente.Servicos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


string conexao = builder.Configuration.GetValue<string>("conexao") ?? string.Empty;
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(conexao);
});

builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IClienteServico, ClienteServico>();

var app = builder.Build();
app.MapEndpoints();
app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.Run();