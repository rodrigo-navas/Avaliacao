using Ploomes.API.Business.Commands;
using Ploomes.API.Business.Exceptions;
using Ploomes.API.Business.Interfaces.Repositories;
using Ploomes.API.Business.Interfaces.Services;
using Ploomes.API.Business.Queries;
using Ploomes.API.Cross.Query;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ploomes.API.Business.Services
{
    public class ClientService : IClientService
    {
        IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<ResultListQuery<ClientQuery>> GetAllAsync()
        {
            var listClient = await _clientRepository.GetAll();
            List<ClientQuery> listReturn = new List<ClientQuery>();

            listClient.ForEach(item =>
            {
                listReturn.Add(new ClientQuery
                {
                    IdClient = item.IdClient,
                    NameClient = item.NameClient,
                    Updated = item.Updated
                });
            });

            return new ResultListQuery<ClientQuery>
            {
                Data = listReturn,
                Total = listReturn.Count
            };
        }

        public async Task<ResultQuery<ClientQuery>> GetByIdAsync(Guid idClient)
        {
            var client = await _clientRepository.GetById(idClient);

            if (client == null)
                throw new NotFoundException("Client not found");

            return new ResultQuery<ClientQuery>(new ClientQuery
            {
                IdClient = client.IdClient,
                NameClient = client.NameClient,
                Updated = client.Updated
            });
        }

        public async Task<ResultQuery> PostAsync(ClientCommand client)
        {
            client.Validate();

            var result = await _clientRepository.GetById(client.IdClient);

            if (result != null)
                throw new ForeignKeyViolationException("Client exists!");

            await _clientRepository.Insert(new Models.ClientModel
            {
                IdClient = client.IdClient,
                NameClient = client.NameClient
            });

            return new ResultQuery
            {
                Message = "Client successfully inserted"
            };
        }

        public async Task<ResultQuery> PutAsync(ClientCommand client)
        {
            client.Validate();

            var result = await _clientRepository.GetById(client.IdClient);

            if (result == null)
                throw new NotFoundException("Client not exists!");

            await _clientRepository.Update(new Models.ClientModel
            {
                IdClient = client.IdClient,
                NameClient = client.NameClient
            });

            return new ResultQuery
            {
                Message = "Client successfully updated"
            };
        }

        public async Task<ResultQuery> DeleteAsync(Guid idClient)
        {
            var client = await _clientRepository.GetById(idClient);

            if (client == null)
                throw new NotFoundException("Client not found");

            await _clientRepository.Remove(client);

            return new ResultQuery
            {
                Message = "Client removed with success!"
            };
        }
    }
}
