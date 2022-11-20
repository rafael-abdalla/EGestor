using EGestor.Shared.Commands;
using FluentValidator;

namespace EGestor.Domain.Commands;

public class InserirUsuarioCommand : Notifiable, ICommand
{
    public InserirUsuarioCommand(Guid pessoaId, string login, string senha)
    {
        PessoaId = pessoaId;
        Login = login;
        Senha = senha;
    }

    public Guid PessoaId { get; set; }
    public string Login { get; set; }
    public string Senha { get; set; }

    public bool IsValid()
    {
        return true;
    }
}
