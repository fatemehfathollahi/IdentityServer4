using Plus.Infrastructure.IdentityServer.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Plus.Infrastructure.IdentityServer.Core.Domain.Repository
{
    public  interface IPlusClientScopeRepository//:IDisposable
    {
        void Insert(ClientScope clientScope);

        void Update(ClientScope clientScope);

        void DeleteAll(int clientId);

        void Delete(int scopeId);

        ClientScope GetById(int scopeId);

        IEnumerable<ClientScope> GetAll();

        IEnumerable<ClientScope> GetScopesByClientId(int clientId);
    }
}
