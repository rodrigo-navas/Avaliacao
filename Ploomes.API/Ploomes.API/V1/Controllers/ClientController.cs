using Microsoft.AspNetCore.Mvc;
using Ploomes.API.Controllers;
using Ploomes.API.Business.Commands;
using Ploomes.API.Business.Interfaces.Services;
using Ploomes.API.Business.Queries;
using Ploomes.API.Cross.Query;
using System;
using System.Threading.Tasks;

namespace Ploomes.API.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/client")]
    public class ClientController : MainController
    {
        IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        [Route("clients")]
        public async Task<ActionResult<ResultListQuery<ClientQuery>>> Get() => CustomResponse(await _clientService.GetAllAsync());

        [HttpGet]
        [Route("clients/{id}")]
        public async Task<ActionResult<ResultQuery<ClientQuery>>> GetById(Guid id) => CustomResponse(await _clientService.GetByIdAsync(id));

        [HttpPost]
        [Route("clients")]
        public async Task<ActionResult<ResultQuery>> Post(ClientCommand client) => CustomResponse(await _clientService.PostAsync(client));

        [HttpPut]
        [Route("clients")]
        public async Task<ActionResult<ResultQuery>> Put(ClientCommand client) => CustomResponse(await _clientService.PutAsync(client));

        [HttpDelete]
        [Route("clients/{id}")]
        public async Task<ActionResult<ResultQuery>> Delete(Guid id) => CustomResponse(await _clientService.DeleteAsync(id));
    }
}
