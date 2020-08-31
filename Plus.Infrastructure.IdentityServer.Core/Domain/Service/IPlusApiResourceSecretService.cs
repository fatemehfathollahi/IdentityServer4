using Plus.Infrastructure.IdentityServer.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Plus.Infrastructure.IdentityServer.Core.Domain.Service
{
    public interface IPlusApiResourceSecretService
    {
        void Insert(int resourceId, ApiResourceSecret apiSecret);

        void Update(int resourceId, ApiResourceSecret apiSecret);

        void Delete(int resourceId, int secretId);

        ApiResourceSecret GetById(int resourceId, int secretId);

        IEnumerable<ApiResourceSecret> GetSecretsByResourceId(int resourceId);
    }
}
