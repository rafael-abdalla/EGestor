using EGestor.Shared.Entities;

namespace EGestor.Domain.Entities;

public class Usuario : Entity
{
    public Usuario(string login, string senha, Guid pessoaId)
    {
        Login = login;
        Senha = senha;
        PessoaId = pessoaId;
        Funcoes = new HashSet<Funcao>();
    }

    public string Login { get; private set; }
    public string Senha { get; private set; }
    public Guid PessoaId { get; private set; }

    public void setSenha(string senha) =>
        Senha = senha;

    public virtual Pessoa Pessoa { get; set; } = null!;
    public virtual ICollection<Lancamento> Lancamentos { get; set; } = null!;
    public virtual ICollection<Funcao> Funcoes { get; set; } = null!;
}
