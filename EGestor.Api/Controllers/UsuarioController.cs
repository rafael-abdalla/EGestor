using EGestor.Domain.Commands;
using EGestor.Domain.Entities;
using EGestor.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace EGestor.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioService _service;

    public UsuarioController(IUsuarioService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Inserir([FromBody] InserirUsuarioCommand command)
    {
        return Ok(await _service.Inserir(command));
    }

    [HttpPost]
    [Route("Login")]
    public async Task<IActionResult> Login([FromBody] LoginCommand login)
    {
        var retorno = await _service.autenticar(login);

        if (retorno.Success)
            return Ok(retorno);

        return Unauthorized(retorno);
    }
}
