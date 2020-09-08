using Plus.Infrastructure.IdentityServer.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Plus.Infrastructure.IdentityServer.Core.Domain.Repository
{
    public interface IPlusClientRedirectUriRepository //: IDisposable
    {
        void Insert(ClientRedirectUri clientRedirectUri);

        void Update(ClientRedirectUri clientRedirectUri);

        void DeleteAll(int clientId);

        void Delete(int clientRedirectUriId);

        ClientRedirectUri GetById(int clientRedirectUriId);

        IEnumerable<ClientRedirectUri> GetAll();

        IEnumerable<ClientRedirectUri> GetRedirectUriByClientId(int clientId);
    }
}
