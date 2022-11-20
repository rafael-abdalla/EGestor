namespace EGestor.Domain.Queries;

public class UsuarioLogadoRetorno
{
    public UsuarioLogadoRetorno(string login)
    {
        Login = login;
        Funcoes = new();
    }

    public string Login { get; set; }
    public string? Token { get; set; }
    public List<FuncaoRetorno> Funcoes { get; set; }
}
