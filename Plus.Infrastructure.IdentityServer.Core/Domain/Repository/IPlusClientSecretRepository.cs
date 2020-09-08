using Plus.Infrastructure.IdentityServer.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Plus.Infrastructure.IdentityServer.Core.Domain.Repository
{
    public interface IPlusClientSecretRepository//:IDisposable
    {
        void Insert(ClientSecret clientSecret);

        void Update(ClientSecret clientSecret);

        void DeleteAll(int clientId);

        void Delete(int secretId);

        ClientSecret GetById(int secretId);

        IEnumerable<ClientSecret> GetAll();

        IEnumerable<ClientSecret> GetSecretsByClientId(int clientId);

    }
}
