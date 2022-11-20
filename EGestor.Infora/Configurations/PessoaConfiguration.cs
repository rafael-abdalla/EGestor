using EGestor.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EGestor.Infra.Configurations;

public class PessoaConfiguration : IEntityTypeConfiguration<Pessoa>
{
    public void Configure(EntityTypeBuilder<Pessoa> builder)
    {
        builder.ToTable("Pessoa");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();

        builder.Property(x => x.Nome).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Apelido).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Documento).HasMaxLength(14);
        builder.Property(x => x.Email).HasMaxLength(150);
        builder.Property(x => x.Telefone).HasMaxLength(15);

        builder.Ignore(x => x.Notifications);
    }
}
