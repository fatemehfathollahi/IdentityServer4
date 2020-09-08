using Plus.Infrastructure.IdentityServer.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Plus.Infrastructure.IdentityServer.Core.Domain.Repository
{
    public interface IPlusApiResourceScopeRepository
    {
        void Insert(ApiResourceScope apiScope);

        void Update(ApiResourceScope apiScope);

        void DeleteAll(int resourceId);

        void Delete(int scopeId);

        ApiResourceScope GetById(int scopeId);

        IEnumerable<ApiResourceScope> GetAll();

        IEnumerable<ApiResourceScope> GetScopesByResourceId(int resourceId);
    }
}
