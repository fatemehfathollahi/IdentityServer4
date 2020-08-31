using Plus.Infrastructure.IdentityServer.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Plus.Infrastructure.IdentityServer.Core.Domain.Service
{
    public interface IPlusApiResourceScopeService
    {
        void Insert(int resourceId,ApiResourceScope apiScope);

        void Update(int resourceId,ApiResourceScope apiScope);

        void Delete(int resourceId,int scopId);

        ApiResourceScope GetById(int resourceId, int scopId);

        IEnumerable<ApiResourceScope> GetScopesByResourceId(int resourceId);
    }
}
