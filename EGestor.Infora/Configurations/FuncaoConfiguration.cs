using EGestor.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EGestor.Infra.Configurations;

public class FuncaoConfiguration : IEntityTypeConfiguration<Funcao>
{
    public void Configure(EntityTypeBuilder<Funcao> builder)
    {
        builder.ToTable("Funcao");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).IsRequired().ValueGeneratedNever();

        builder.Property(x => x.Descricao).IsRequired().HasMaxLength(1000);

        builder.Ignore(x => x.Notifications);

        builder.HasData(
            new Funcao(Guid.Parse("37c4aa84-746d-4856-9f64-d0d9891df1b9"), "ADMINISTRADOR"),
            new Funcao(Guid.Parse("3847181b-2014-43df-a92b-1d4644871757"), "DESENVOLVEDOR"),
            new Funcao(Guid.Parse("17ee9760-3dc0-43bc-9f60-a0520370a5a0"), "FUNCIONÁRIO"),
            new Funcao(Guid.Parse("bd3ab10d-da53-4444-817d-5f8593667921"), "CLIENTE")
        );
    }
}
