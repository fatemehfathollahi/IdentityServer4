using Plus.Infrastructure.IdentityServer.Core.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Plus.Infrastructure.IdentityServer.Core.Domain.Repository
{
    public interface IPlusApiResourceRepository
    {
        Task<int> Insert(ApiResource apiResource);

        Task<int> Update(ApiResource apiResource);

        Task Delete(int id);

        Task<ApiResource> GetById(int id);

        Task<IEnumerable<ApiResource>> GetAll();
    }
}
