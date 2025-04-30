using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using core.cliente.Entidades;

namespace api.cliente.Data.Mapping;

public class ClienteMapping: IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.ToTable("Cliente");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .ValueGeneratedOnAdd();

        builder.Property(c => c.Nome)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(c => c.Email)
            .IsRequired()
            .HasMaxLength(180);

        builder.Property(c => c.CPF)
            .IsRequired()
            .HasMaxLength(14);

        builder.Property(c => c.RG)
            .IsRequired()
            .HasMaxLength(12);
        
        builder.HasMany(c => c.Contatos)
            .WithOne()
            .HasForeignKey( c => c.IdCliente)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(c => c.Enderecos)
            .WithOne()
            .HasForeignKey(e => e.IdCliente)
            .OnDelete(DeleteBehavior.Cascade);
    }
}