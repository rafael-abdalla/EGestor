using EGestor.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EGestor.Infra.Configurations;

public class LancamentoConfiguration : IEntityTypeConfiguration<Lancamento>
{
    public void Configure(EntityTypeBuilder<Lancamento> builder)
    {
        builder.ToTable("Lancamento");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).IsRequired().ValueGeneratedNever();
        builder.Property(x => x.UsuarioId).IsRequired();
        builder.Property(x => x.Criacao).IsRequired();

        builder.HasOne(x => x.Usuario).WithMany(x => x.Lancamentos).HasForeignKey(x => x.UsuarioId);

        builder.HasIndex(x => x.Criacao).IsUnique(false);
    }
}
