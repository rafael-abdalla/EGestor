using MediatR;

namespace EGestor.Shared.Commands;

public interface ICommand : IRequest<CommandResult>
{
    bool IsValid();
}
