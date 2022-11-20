using EGestor.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EGestor.Infra.Configurations;

public class FuncionarioConfiguration : IEntityTypeConfiguration<Funcionario>
{
    public void Configure(EntityTypeBuilder<Funcionario> builder)
    {
        builder.ToTable("Funcionario");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).IsRequired().ValueGeneratedNever();

        builder.Property(x => x.PessoaId).IsRequired();
        builder.Property(x => x.DataAdmissao);
        builder.Property(x => x.Observacao).HasMaxLength(1000);

        builder.HasOne(x => x.Pessoa).WithMany(x => x.Funcionarios).HasForeignKey(x => x.PessoaId);

        builder.Ignore(x => x.Notifications);
    }
}
