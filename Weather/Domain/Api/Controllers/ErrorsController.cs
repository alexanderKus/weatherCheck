using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

public class ErrorsController : ControllerBase
{
    [Route("/errors")]
    public IActionResult Erros()
    {
        return Problem();
    }
}
