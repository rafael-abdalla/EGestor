using EGestor.Domain.Commands;
using EGestor.Domain.Entities;
using EGestor.Shared.Commands;

namespace EGestor.Domain.Services;

public interface IUsuarioService
{
    Task<CommandResult> autenticar(LoginCommand usuario);
    Task<CommandResult> Inserir(InserirUsuarioCommand command);
}
