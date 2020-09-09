using Plus.Infrastructure.IdentityServer.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Plus.Infrastructure.IdentityServer.Core.Domain.Repository
{
    public interface IPlusClientCorsOriginRepository
    {
        Task Insert(ClientCorsOrigin clientCorsOrigin);

        Task Update(ClientCorsOrigin clientCorsOrigin);

        Task DeleteAll(int clientId);

        Task Delete(int corsOriginId);

        Task<ClientCorsOrigin> GetById(int corsOriginId);

        Task<IEnumerable<ClientCorsOrigin>> GetAll();

        Task<IEnumerable<ClientCorsOrigin>> GetCorsOriginByClientId(int clientId);
    }
}
