using EGestor.Domain.Commands;
using EGestor.Domain.Entities;
using EGestor.Domain.Repositories;
using EGestor.Shared.Commands;
using FluentValidator;
using MediatR;

namespace EGestor.Domain.Handlers;

public class UsuarioHandler :
    Notifiable,
    IRequestHandler<InserirUsuarioCommand, CommandResult>
{
    private readonly IUsuarioRepository _repository;
    private readonly IUnitOfWork _uow;

    public UsuarioHandler(IUsuarioRepository repository, IUnitOfWork uow)
    {
        _repository = repository;
        _uow = uow;
    }

    public async Task<CommandResult> Handle(InserirUsuarioCommand command, CancellationToken cancellationToken)
    {
        var usuario = new Usuario(command.Login, command.Senha, command.PessoaId);

        AddNotifications(usuario.Notifications);

        if (usuario.Invalid)
        {
            return await Task.FromResult(new CommandResult(false, "Informe os campos abaixo", Notifications));
        }

        await _uow.BeginTransaction();

        await _repository.Inserir(usuario);

        var commit = await _uow.Commit();
        if (!commit)
        {
            await _uow.Rollback();

            return await Task.FromResult(
                new CommandResult(false, "Houve rollback na operação", Notifications)
            );
        }

        return await Task.FromResult(new CommandResult(true, "Cadastrado", new { usuario.Id, usuario.Login }));
    }
}
