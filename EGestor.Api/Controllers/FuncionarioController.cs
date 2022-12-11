using EGestor.Domain.Commands;
using EGestor.Domain.Services;
using EGestor.Shared.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EGestor.Api.Controllers;

[Route("v1/api/[controller]")]
[ApiController]
[Authorize(Roles = "DESENVOLVEDOR")]
public class FuncionarioController : ControllerBase
{
    private readonly IFuncionarioService _service;

    public FuncionarioController(IFuncionarioService service)
    {
        _service = service;
    }

    [HttpGet]
    [ProducesResponseType(typeof(CommandResult), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(CommandResult), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> BuscarTodos()
    {
        return Ok(await _service.BuscarTodos());
    }

    [HttpPost]
    [ProducesResponseType(typeof(CommandResult), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(CommandResult), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(CommandResult), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Inserir([FromBody] InserirFuncionarioCommand command)
    {
        return Ok(await _service.Inserir(command));
    }
}
