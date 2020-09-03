using Plus.Infrastructure.IdentityServer.Core.Domain.Models;
using Plus.Infrastructure.IdentityServer.Core.Domain.Repository;
using Plus.Infrastructure.IdentityServer.Core.Domain.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Plus.Infrastructure.IdentityServer.Core.Service
{
    public class PlusClientService : IPlusClientService
    {
        private readonly IPlusClientRepository _clientRepository;

        public PlusClientService(IPlusClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public void Delete(int id)
        {
            _clientRepository.Delete(id);
        }

        public IEnumerable<Client> GetAll()
        {
           return _clientRepository.GetAll();
        }

        public Client GetById(string id)
        {
            return _clientRepository.GetById(id);
        }

        public void Insert(Client client)
        {
            _clientRepository.Insert(client);
        }

        public void Update(Client client)
        {
            _clientRepository.Update(client);
        }
    }
}
