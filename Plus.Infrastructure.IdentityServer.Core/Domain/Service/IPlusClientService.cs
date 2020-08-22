using IdentityServer4.Models;
using Plus.Infrastructure.IdentityServer.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Client = Plus.Infrastructure.IdentityServer.Core.Domain.Models.Client;

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
