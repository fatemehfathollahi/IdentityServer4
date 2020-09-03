using Plus.Infrastructure.IdentityServer.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Plus.Infrastructure.IdentityServer.Core.Domain.Repository
{
    public interface IPlusClientRepository: IDisposable
    {
        void Insert(Client client);

        void Update(Client client);

        void Delete(int id);

        Client GetById(string id);

        IEnumerable<Client> GetAll();
    }
}
