using EGestor.Shared.Commands;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EGestor.Api.Controllers;


[ApiController]
[ApiExplorerSettings(IgnoreApi = true)]
public class ErrorController : ControllerBase
{
    [Route("error")]
    public IActionResult Error()
    {
        var contexto = HttpContext.Features.Get<IExceptionHandlerFeature>();
        var exception = contexto?.Error;

        var errorId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;

        var retorno = new CommandResult(false, "Algo deu errado! Favor contatar o suporte.", new { Erro = exception?.Message });

        return StatusCode(StatusCodes.Status500InternalServerError, retorno);
    }
}
