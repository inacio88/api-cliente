using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using core.cliente.Entidades;

namespace api.cliente.Data.Mapping;

public class EnderecoMapping: IEntityTypeConfiguration<Endereco>
{
    public void Configure(EntityTypeBuilder<Endereco> builder)
    {
        builder.ToTable("Endereco");

        builder.HasKey(e => e.Id);
        
        builder.Property(e => e.IdCliente)
            .IsRequired();

        builder.Property(e => e.Tipo)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(e => e.CEP)
            .IsRequired()
            .HasMaxLength(9); // Ex: 00000-000

        builder.Property(e => e.Logradouro)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(e => e.Numero)
            .IsRequired();

        builder.Property(e => e.Bairro)
            .IsRequired()
            .HasMaxLength(80);

        builder.Property(e => e.Complemento)
            .HasMaxLength(100);

        builder.Property(e => e.Cidade)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(e => e.Estado)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(e => e.Referencia)
            .HasMaxLength(150);
    }
}