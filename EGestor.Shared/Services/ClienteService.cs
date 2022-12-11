using EGestor.Domain.Commands;
using EGestor.Domain.Entities;
using EGestor.Domain.Queries;
using EGestor.Domain.Repositories;
using EGestor.Domain.Services;
using EGestor.Shared.Commands;
using FluentValidator;
using MediatR;

namespace EGestor.Shared.Services;

public class ClienteService : Notifiable, IClienteService
{
    private readonly IMediator _mediator;
    private readonly IClienteRepository _repository;

    public ClienteService(IMediator mediator, IClienteRepository repository)
    {
        _mediator = mediator;
        _repository = repository;
    }

    public async Task<CommandResult> BuscarPorId(Guid id)
    {
        Cliente retorno = await _repository.BuscarPorId(id);
        var procura = new ClienteProcuraRetorno(retorno.Id, retorno.Pessoa.Id, retorno.Pessoa.Documento, retorno.Pessoa.Nome, retorno.Pessoa.Email, retorno.LimiteCredito, retorno.Ativo);
        return new CommandResult(true, "Consulta", procura);
    }

    public async Task<CommandResult> BuscarTodos()
    {
        List<Cliente> retorno = await _repository.BuscarTodos();

        var clientes = retorno
            .Select(x => new ClienteProcuraRetorno(x.Id, x.Pessoa.Id, x.Pessoa.Documento, x.Pessoa.Nome, x.Pessoa.Email, x.LimiteCredito, x.Ativo))
            .ToList();

        return new CommandResult(true, "Consulta", clientes);
    }

    public async Task<CommandResult> Inserir(InserirClienteCommand command)
    {
        if (await _repository.DocumentoExiste(command.Documento))
        {
            AddNotification("Documento", "Documento já existe");

            return await Task.FromResult(
                new CommandResult(false, "Verifique os campos abaixo", Notifications)
            );
        }

        var retorno = await _mediator.Send(command)!;
        return retorno;
    }
}
