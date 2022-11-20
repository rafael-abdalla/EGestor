using EGestor.Shared.Entities;

namespace EGestor.Domain.Entities;

public class Usuario : Entity
{
    public Usuario(string login, string senha, Guid funcionarioId)
    {
        Login = login;
        Senha = senha;
        FuncionarioId = funcionarioId;
        Funcoes = new HashSet<Funcao>();
    }

    public string Login { get; private set; }
    public string Senha { get; private set; }
    public Guid FuncionarioId { get; private set; }

    public void setSenha(string senha) =>
        Senha = senha;

    public virtual Funcionario Funcionario { get; set; } = null!;
    public virtual ICollection<Lancamento> Lancamentos { get; set; } = null!;
    public virtual ICollection<Funcao> Funcoes { get; set; } = null!;
}
