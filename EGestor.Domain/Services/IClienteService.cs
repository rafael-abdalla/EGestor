namespace EGestor.Domain.Services;

public interface IClienteService
{
    Task<CommandResult> BuscarTodos();
    Task<CommandResult> BuscarPorId(Guid id);
    Task<CommandResult> Inserir(InserirClienteCommand command);
}
