using EGestor.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EGestor.Infra.Configurations;

public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.ToTable("Cliente");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).IsRequired().ValueGeneratedNever();

        builder.Property(x => x.PessoaId).IsRequired();
        builder.Property(x => x.LimiteCredito);
        builder.Property(x => x.Observacao).HasMaxLength(1000);
        builder.Property(x => x.Ativo).IsRequired();

        builder.HasOne(x => x.Pessoa).WithMany(x => x.Clientes).HasForeignKey(x => x.PessoaId);

        builder.Ignore(x => x.Notifications);
    }
}
