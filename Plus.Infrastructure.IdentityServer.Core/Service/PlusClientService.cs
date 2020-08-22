using Plus.Infrastructure.IdentityServer.Core.Domain.Models;
using Plus.Infrastructure.IdentityServer.Core.Domain.Repository;
using Plus.Infrastructure.IdentityServer.Core.Domain.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Plus.Infrastructure.IdentityServer.Core.Service
{
    public class PlusClientService : IPlusClientService,IDisposable
    {
        private readonly IPlusClientRepository clientRepository;

        public PlusClientService(IPlusClientRepository clientRepository)
        {
            this.clientRepository = clientRepository;
        }

        public void Dispose()
        {
          
        }

        public IEnumerable<Client> GetAll()
        {
            return clientRepository.GetAll();
        }

        public Client GetByClientId(string clientId)
        {
            return clientRepository.GetByClientId(clientId);
        }

        public Client Insert(Client client)
        {
            throw new NotImplementedException();
        }

        public bool UpdateClient(Client client)
        {
            throw new NotImplementedException();
        }
    }
}
