using FluentValidator.Validation;

namespace EGestor.Domain.Commands;

public class InserirUsuarioCommand : Notifiable, ICommand
{
    public InserirUsuarioCommand(Guid funcionarioId, string login, string senha)
    {
        FuncionarioId = funcionarioId;
        Login = login;
        Senha = senha;
        Funcoes = new();
    }

    public Guid FuncionarioId { get; set; }
    public string Login { get; set; }
    public string Senha { get; set; }
    public HashSet<Guid> Funcoes { get; set; }

    public bool IsValid()
    {
        AddNotifications(new ValidationContract()
            .Requires()
            .HasMinLen(Login, 3, "Login", "O login deve conter pelo menos 3 caracteres")
            .HasMaxLen(Login, 100, "Login", "O login deve conter no máximo 100 caracteres")
            .HasMinLen(Senha, 6, "Senha", "A senha deve conter pelo menos 6 caracteres")
            .HasMaxLen(Senha, 1024, "Senha", "A senha deve conter no máximo 1024 caracteres")
        );

        return Valid;
    }
}
