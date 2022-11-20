namespace EGestor.Domain.Handlers;

public class ClienteHandler : 
    Notifiable,
    IRequestHandler<InserirClienteCommand, CommandResult>
{
    private readonly IClienteRepository _repository;
    private readonly IUnitOfWork _uow;

    public ClienteHandler(IClienteRepository repository, IUnitOfWork uow)
    {
        _repository = repository;
        _uow = uow;
    }

    public async Task<CommandResult> Handle(InserirClienteCommand command, CancellationToken cancellationToken)
    {
        var pessoa = new Pessoa(command.Nome, command.Apelido, command.Documento, command.Telefone, command.Email);
        var cliente = new Cliente(pessoa.Id, command.LimiteCredito, command.Observacao);

        AddNotifications(pessoa.Notifications);
        AddNotifications(cliente.Notifications);

        if (pessoa.Invalid || cliente.Invalid)
        {
            return await Task.FromResult(
                new CommandResult(false, "Informe os campos abaixo", Notifications)
            );
        }
        
        cliente.Pessoa = pessoa;

        await _uow.BeginTransaction();

        await _repository.Inserir(cliente);

        var commit = await _uow.Commit();
        if (!commit)
        {
            await _uow.Rollback();

            return await Task.FromResult(
                new CommandResult(false, "Houve rollback na operação", Notifications)
            );
        }

        var retorno = new { cliente.Id, pessoa.Nome, pessoa.Apelido, pessoa.Email };

        return await Task.FromResult(
            new CommandResult(true, "Cadastrado", retorno)
        );
    }
}
