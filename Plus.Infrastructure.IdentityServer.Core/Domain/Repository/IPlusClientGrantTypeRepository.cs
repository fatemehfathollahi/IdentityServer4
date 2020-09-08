using Plus.Infrastructure.IdentityServer.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Plus.Infrastructure.IdentityServer.Core.Domain.Repository
{
    public interface IPlusClientGrantTypeRepository//:IDisposable
    {
        void Insert(ClientGrantType clientGrantType);

        void Update(ClientGrantType clientGrantType);

        void DeleteAll(int clientId);

        void Delete(int grantTypeId);

        ClientGrantType GetById(int grantTypeId);

        IEnumerable<ClientGrantType> GetAll();

        IEnumerable<ClientGrantType> GetGrantTypesByClientId(int clientId);
    }
}
