using EGestor.Domain.Commands;

namespace EGestor.Domain.Services;

public interface IFuncionarioService
{
    Task<CommandResult> BuscarTodos();
    Task<CommandResult> Inserir(InserirFuncionarioCommand command);
}
