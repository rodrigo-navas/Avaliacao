using Microsoft.AspNetCore.Mvc;
using Ploomes.Cross.Query;
using System.Security.Claims;

namespace Ploomes.API.Controllers
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
