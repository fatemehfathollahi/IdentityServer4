using Plus.Infrastructure.IdentityServer.Core.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Plus.Infrastructure.IdentityServer.Core.Domain.Repository
{
    public interface IPlusApiResourceScopeRepository
    {
        Task Insert(ApiResourceScope apiScope);

        Task Update(ApiResourceScope apiScope);

        Task DeleteAll(int resourceId);

        Task Delete(int scopeId);

        Task<ApiResourceScope> GetById(int scopeId);

        Task<IEnumerable<ApiResourceScope>> GetAll();

        Task<IEnumerable<ApiResourceScope>> GetScopesByResourceId(int resourceId);
    }
}
