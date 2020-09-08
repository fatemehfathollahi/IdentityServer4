using Plus.Infrastructure.IdentityServer.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Plus.Infrastructure.IdentityServer.Core.Domain.Service
{
    public interface IPlusApiResourceSecretService
    {
        void Insert(ApiResourceSecret apiSecret);

        void Update(ApiResourceSecret apiSecret);

        void Delete(int secretId);

        void DeleteAll(int resourceId);

        ApiResourceSecret GetById(int secretId);

        IEnumerable<ApiResourceSecret> GetAll();

        IEnumerable<ApiResourceSecret> GetSecretsByResourceId(int resourceId);
    }
}
