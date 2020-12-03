using Microsoft.AspNetCore.Mvc;
using Avaliacao.API.Controllers;
using Avaliacao.API.Business.Commands;
using Avaliacao.API.Business.Interfaces.Services;
using Avaliacao.API.Business.Queries;
using Avaliacao.API.Cross.Query;
using System;
using System.Threading.Tasks;

namespace Avaliacao.API.V1.Controllers
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
