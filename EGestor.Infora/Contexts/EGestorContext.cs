using EGestor.Domain.Entities;
using EGestor.Infra.Configurations;
using Microsoft.EntityFrameworkCore;

namespace EGestor.Infra.Contexts;

public class EGestorContext : DbContext
{
    public EGestorContext(DbContextOptions options)
        : base(options) { }

    public DbSet<Lancamento> Lancamentos { get; set; }
    public DbSet<Pessoa> Pessoa { get; set; }
    public DbSet<Funcionario> Funcionarios { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Funcao> Funcoes { get; set; }
    public DbSet<Usuario> Usuario { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new LancamentoConfiguration());
        modelBuilder.ApplyConfiguration(new PessoaConfiguration());
        modelBuilder.ApplyConfiguration(new FuncionarioConfiguration());
        modelBuilder.ApplyConfiguration(new ClienteConfiguration());
        modelBuilder.ApplyConfiguration(new FuncaoConfiguration());
        modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
    }

}
