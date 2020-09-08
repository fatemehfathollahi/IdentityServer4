using Plus.Infrastructure.IdentityServer.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Plus.Infrastructure.IdentityServer.Core.Domain.Repository
{
    public interface IPlusApiResourceSecretRepository
    {
        void Insert(ApiResourceSecret apiSecret);

        void Update(ApiResourceSecret apiSecret);

        void DeleteAll(int resourceId);

        void Delete(int secretId);

        ApiResourceSecret GetById(int secretId);

        IEnumerable<ApiResourceSecret> GetAll();

        IEnumerable<ApiResourceSecret> GetSecretsByResourceId(int resourceId);
    }
}
