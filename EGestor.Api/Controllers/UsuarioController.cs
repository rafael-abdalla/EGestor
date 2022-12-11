using EGestor.Domain.Commands;
using EGestor.Domain.Services;
using EGestor.Shared.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EGestor.Api.Controllers;

[Route("v1/api/[controller]")]
[ApiController]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioService _service;

    public UsuarioController(IUsuarioService service)
    {
        _service = service;
    }

    [HttpPost]
    [ProducesResponseType(typeof(CommandResult), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(CommandResult), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(CommandResult), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Inserir([FromBody] InserirUsuarioCommand command)
    {
        var retorno = await _service.Inserir(command);
        if (retorno.Success)
            return Ok();

        return BadRequest(retorno);
    }

    [HttpPost]
    [Route("login")]
    [ProducesResponseType(typeof(CommandResult), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(CommandResult), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(CommandResult), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Login([FromBody] LoginCommand login)
    {
        var retorno = await _service.Autenticar(login);

        if (retorno.Success)
            return Ok(retorno);

        return Unauthorized(retorno);
    }

    [HttpGet]
    [Route("funcoes")]
    [ProducesResponseType(typeof(CommandResult), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(CommandResult), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Funcoes()
    {
        return Ok(await _service.BuscarFuncoes());
    }
}
