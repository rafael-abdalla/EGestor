using EGestor.Domain.Commands;
using EGestor.Domain.Entities;
using EGestor.Domain.Queries;
using EGestor.Domain.Repositories;
using EGestor.Domain.Services;
using EGestor.Shared.Commands;
using FluentValidator;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace EGestor.Shared.Services;

public class UsuarioService : Notifiable, IUsuarioService
{
    private readonly IUsuarioRepository _repository;
    private readonly IMediator _mediator;
    private readonly IJwtService _jwtService;

    public UsuarioService(IUsuarioRepository repository, IMediator mediator, IJwtService jwtService)
    {
        _repository = repository;
        _mediator = mediator;
        _jwtService = jwtService;
    }

    public async Task<CommandResult> autenticar(LoginCommand usuario)
    {
        var procura = await _repository.BuscarPorLogin(usuario.Login);
        if (procura == null)
        {
            AddNotification("Login", "Login não encontrado");

            return await Task.FromResult(new CommandResult(false, "Verifique os campos abaixo", Notifications));
        }

        if (ValidaEAtualizaHash(usuario, procura.Senha))
        {
            var usuarioLogado = new UsuarioLogadoRetorno(procura.Login);
            usuarioLogado.Token = _jwtService.obterJwt(procura);
            var funcoes = procura.Funcoes.Select(x => new FuncaoRetorno(x.Id, x.Descricao)).ToList();
            usuarioLogado.Funcoes = funcoes;
            return await Task.FromResult(new CommandResult(true, "Autenticado", usuarioLogado));
        }

        return await Task.FromResult(new CommandResult(false, "Falha ao autenticar", new { Erro = "Usuario e/ou Senha incorretos" }));
    }

    private bool ValidaEAtualizaHash(LoginCommand usuario, string hash)
    {
        var passwordHasher = new PasswordHasher<LoginCommand>();
        var status = passwordHasher.VerifyHashedPassword(usuario, hash, usuario.Senha);

        switch (status)
        {
            case PasswordVerificationResult.Failed:
                return false;
            case PasswordVerificationResult.Success:
                return true;
            case PasswordVerificationResult.SuccessRehashNeeded:
                return true;
            default:
                throw new InvalidOperationException();
        }
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
