namespace EGestor.Domain.Services;

public interface IUsuarioService
{
    Task<CommandResult> BuscarFuncoes();
    Task<CommandResult> Autenticar(LoginCommand usuario);
    Task<CommandResult> Inserir(InserirUsuarioCommand command);
}
