using EGestor.Domain.Commands;
using EGestor.Domain.Repositories;
using EGestor.Domain.Services;
using EGestor.Shared.Commands;
using FluentValidator;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGestor.Shared.Services;

public class UsuarioService : Notifiable, IUsuarioService
{
    private readonly IUsuarioRepository _repository;
    private readonly IMediator _mediator;

    public UsuarioService(IUsuarioRepository repository, IMediator mediator)
    {
        _repository = repository;
        _mediator = mediator;
    }

    public async Task<CommandResult> Inserir(InserirUsuarioCommand command)
    {
        if (await _repository.LoginExiste(command.Login))
        {
            AddNotification("Login", "Login já existe");

            return await Task.FromResult(
                new CommandResult(false, "Verifique os campos abaixo", Notifications)
            );
        }

        return await _mediator.Send(command);
    }
}
