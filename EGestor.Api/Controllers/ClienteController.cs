using EGestor.Domain.Commands;
using EGestor.Domain.Entities;
using EGestor.Domain.Services;
using EGestor.Shared.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace EGestor.Api.Controllers;

[Route("v1/api/[controller]")]
[ApiController]
[Authorize(Roles = "DESENVOLVEDOR")]
public class ClienteController : ControllerBase
{
    private readonly IClienteService _service;

    public ClienteController(IClienteService service)
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
    public async Task<IActionResult> Inserir([FromBody] InserirClienteCommand command)
    {
        var retorno = await _service.Inserir(command);
        if (retorno.Success)
            return Ok(retorno);

        return BadRequest(retorno);
    }
}
