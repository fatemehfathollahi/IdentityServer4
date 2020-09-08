using Plus.Infrastructure.IdentityServer.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Plus.Infrastructure.IdentityServer.Core.Domain.Repository
{
    public interface IPlusClientCorsOriginRepository
    {
        void Insert(ClientCorsOrigin clientCorsOrigin);

        void Update(ClientCorsOrigin clientCorsOrigin);

        void DeleteAll(int clientId);

        void Delete(int corsOriginId);

        ClientCorsOrigin GetById(int corsOriginId);

        IEnumerable<ClientCorsOrigin> GetAll();

        IEnumerable<ClientCorsOrigin> GetCorsOriginByClientId(int clientId);
    }
}
