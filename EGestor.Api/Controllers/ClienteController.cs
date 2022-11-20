using EGestor.Domain.Commands;
using EGestor.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace EGestor.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClienteController : ControllerBase
{
    private readonly IClienteService _service;

    public ClienteController(IClienteService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> BuscarTodos()
    {
        return Ok(await _service.BuscarTodos());
    }

    [HttpPost]
    public async Task<IActionResult> Inserir([FromBody] InserirClienteCommand command)
    {
        var retorno = await _service.Inserir(command);
        return Ok(retorno);
    }
}
