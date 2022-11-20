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

        var retorno = new {
            Success = false,
            Message = "Algo deu errado! Favor contatar o suporte.",
            Data = new { Erro = exception?.Message }
        };

        return StatusCode(StatusCodes.Status500InternalServerError, retorno);
    }
}
