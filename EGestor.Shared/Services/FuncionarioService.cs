using EGestor.Domain.Commands;
using EGestor.Domain.Queries;
using EGestor.Domain.Repositories;
using EGestor.Domain.Services;
using EGestor.Shared.Commands;
using MediatR;

namespace EGestor.Shared.Services;

public class FuncionarioService : IFuncionarioService
{
    private IFuncionarioRepository _repository;
    private IMediator _mediator;
    public FuncionarioService(IFuncionarioRepository repository, IMediator mediator)
    {
        _repository = repository;
        _mediator = mediator;
    }

    public async Task<CommandResult> BuscarTodos()
    {
        var retorno = await _repository.BuscarTodos();

        var funcionarios = retorno
            .Select(x => new FuncionarioProcuraRetorno(x.Id, x.Pessoa.Nome, x.Observacao, x.DataAdmissao))
            .ToList();

        return await Task.FromResult(
            new CommandResult(true, "Consulta", funcionarios)
        );
    }

    public async Task<CommandResult> Inserir(InserirFuncionarioCommand command)
    {
        return await _mediator.Send(command);
    }
}
