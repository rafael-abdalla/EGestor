using Microsoft.AspNetCore.Identity;

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
        var usuario = new Usuario(command.Login, command.Senha, command.FuncionarioId);

        ConverterSenhaEmHash(usuario);

        AddNotifications(usuario.Notifications);

        if (usuario.Invalid)
        {
            return await Task.FromResult(new CommandResult(false, "Informe os campos abaixo", Notifications));
        }

        await _uow.BeginTransaction();


        List<Funcao> funcoes = new();
        foreach (var funcaoId in command.Funcoes)
        {
            var funcao = await _repository.BuscarFuncaoPorId(funcaoId);
            funcoes.Add(funcao!);
        }

        usuario.Funcoes = funcoes;

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

    private void ConverterSenhaEmHash(Usuario usuario)
    {
        var passwordHasher = new PasswordHasher<Usuario>();
        var senhaComHash = passwordHasher.HashPassword(usuario, usuario.Senha);
        usuario.setSenha(senhaComHash);
    }
}
