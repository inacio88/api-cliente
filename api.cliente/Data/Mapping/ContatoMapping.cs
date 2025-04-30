using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using core.cliente.Entidades;
namespace api.cliente.Data.Mapping;

public class ContatoMapping: IEntityTypeConfiguration<Contato>
{
    public void Configure(EntityTypeBuilder<Contato> builder)
    {
        builder.ToTable("Contato");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.IdCliente)
            .IsRequired();

        builder.Property(c => c.Tipo)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(c => c.DDD)
            .IsRequired();

        builder.Property(c => c.Telefone)
            .IsRequired()
            .HasColumnType("decimal(15,0)");
    }
}