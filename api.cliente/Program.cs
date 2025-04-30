using api.cliente.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


string conexao = builder.Configuration.GetValue<string>("conexao") ?? string.Empty;
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(conexao);
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.Run();