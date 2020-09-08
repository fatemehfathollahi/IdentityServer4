using Plus.Infrastructure.IdentityServer.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Plus.Infrastructure.IdentityServer.Core.Domain.Repository
{
    public interface IPlusClientClaimRepository//:IDisposable
    {
        void Insert(ClientClaim clientClaim);

        void Update(ClientClaim clientClaim);

        void DeleteAll(int clientId);

        void Delete(int claimId);

        ClientClaim GetById(int claimId);

        IEnumerable<ClientClaim> GetAll();

        IEnumerable<ClientClaim> GetClaimsByClientId(int clientId);
    }
}
