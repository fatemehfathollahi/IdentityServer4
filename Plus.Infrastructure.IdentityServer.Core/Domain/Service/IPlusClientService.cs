using System.Collections.Generic;
using  Plus.Infrastructure.IdentityServer.Core.Domain.Models;

namespace Plus.Infrastructure.IdentityServer.Core.Domain.Service
{
    public interface IPlusClientService
    {
        void Insert(Client client);

        void Update(Client client);

        void Delete(int id);

        Client GetById(string id);

        IEnumerable<Client> GetAll();

    }
}
