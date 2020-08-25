using System.Collections.Generic;
using  Plus.Infrastructure.IdentityServer.Core.Domain.Models;

namespace Plus.Infrastructure.IdentityServer.Core.Domain.Service
{
    public interface IPlusClientService
    {
        Client Insert(Client client);
        bool UpdateClient(Client client);
        Client GetByClientId(string clientId);
        IEnumerable<Client> GetAll();

    }
}
