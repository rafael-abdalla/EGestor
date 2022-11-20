using EGestor.Domain.Entities;

namespace EGestor.Domain.Handlers
{
    internal class FuncionarioHandler :
        Notifiable,
        IRequestHandler<InserirFuncionarioCommand, CommandResult>
    {
        private readonly IFuncionarioRepository _repository;
        private readonly IUnitOfWork _uow;

        public FuncionarioHandler(IFuncionarioRepository repository, IUnitOfWork uow)
        {
            _repository = repository;
            _uow = uow;
        }

        public async Task<CommandResult> Handle(InserirFuncionarioCommand command, CancellationToken cancellationToken)
        {
            var pessoa = new Pessoa(command.Nome, command.Apelido, command.Documento, command.Telefone, command.Email);
            var funcionario = new Funcionario(pessoa.Id, command.DataAdmissao, command.Observacao);

            AddNotifications(pessoa);
            AddNotifications(funcionario);

            if (pessoa.Invalid || funcionario.Invalid)
            {
                return await Task.FromResult(
                    new CommandResult(false, "Informe os campos abaixo", Notifications)
                );
            }

            funcionario.Pessoa = pessoa;

            await _uow.BeginTransaction();

            await _repository.Inserir(funcionario);

            var commit = await _uow.Commit();
            if (!commit)
            {
                await _uow.Rollback();

                return await Task.FromResult(
                    new CommandResult(false, "Houve rollback na operação", Notifications)
                );
            }

            var retorno = new { funcionario.Id, pessoa.Nome, pessoa.Apelido, pessoa.Email, funcionario.Observacao };

            return await Task.FromResult(
                new CommandResult(true, "Cadastrado", retorno)
            );
        }
    }
}
