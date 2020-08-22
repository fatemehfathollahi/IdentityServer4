using Plus.Infrastructure.IdentityServer.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Plus.Infrastructure.IdentityServer.Core.Domain.Repository
{
    public interface IPlusClientRepository
    {
        void Insert(Client client);

        void Update(Client client);

        Client GetByClientId(string clientId);

        IEnumerable<Client> GetAll();
    }
}
