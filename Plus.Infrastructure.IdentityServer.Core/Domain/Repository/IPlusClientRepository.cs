using Plus.Infrastructure.IdentityServer.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Plus.Infrastructure.IdentityServer.Core.Domain.Repository
{
    public interface IPlusClientRepository//: IDisposable
    {
        int Insert(Client client);

        int Update(Client client);

        int Delete(int id);

        Client GetById(int id);

        IEnumerable<Client> GetAll();
    }
}
