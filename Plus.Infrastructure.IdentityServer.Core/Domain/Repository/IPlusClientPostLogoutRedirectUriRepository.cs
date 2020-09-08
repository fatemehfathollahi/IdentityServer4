using Plus.Infrastructure.IdentityServer.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Plus.Infrastructure.IdentityServer.Core.Domain.Repository
{
    public interface IPlusClientPostLogoutRedirectUriRepository//: IDisposable
    {
        void Insert(ClientPostLogoutRedirectUri clientPostLogoutRedirectUri);

        void Update(ClientPostLogoutRedirectUri clientPostLogoutRedirectUri);//

        void DeleteAll(int clientId);

        void Delete(int clientPostLogoutRedirectUriId);

        ClientPostLogoutRedirectUri GetById(int clientPostLogoutRedirectUriId);

        IEnumerable<ClientPostLogoutRedirectUri> GetAll();

        IEnumerable<ClientPostLogoutRedirectUri> GetPostLogoutRedirectUrisByClientId(int clientId);
    }
}
