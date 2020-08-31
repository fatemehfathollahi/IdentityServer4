using Plus.Infrastructure.IdentityServer.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Plus.Infrastructure.IdentityServer.Core.Domain.Repository
{
    public interface IPlusApiResourceScopeRepository:IDisposable
    {
        void Insert(int resourceId,ApiResourceScope apiScope);

        void Update(int resourceId,ApiResourceScope apiScope);

        void Delete(int resourceId, int scopeId);

        ApiResourceScope GetById(int resourceId,int scopeId);

       // IEnumerable<ApiResourceScope> GetAll();

        IEnumerable<ApiResourceScope> GetScopesByResourceId(int resourceId);
    }
}
