using Microsoft.AspNetCore.Mvc;
using Avaliacao.API.Cross.Query;
using System.Security.Claims;

namespace Avaliacao.API.Controllers
{
    [ApiController]
    public abstract class MainController : ControllerBase
    {
        protected ActionResult CustomResponse(ResultQuery rExecucao)
        {
            if (rExecucao.LstError.Count == 0)
                return Ok(rExecucao);
            else
                return BadRequest(rExecucao);
        }
    }
}
