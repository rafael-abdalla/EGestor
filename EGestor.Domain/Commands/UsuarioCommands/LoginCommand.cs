namespace EGestor.Domain.Commands;

public class LoginCommand
{
    public LoginCommand(string login, string senha)
    {
        Login = login;
        Senha = senha;
    }

    public string Login { get; private set; }
    public string Senha { get; private set; }
}
