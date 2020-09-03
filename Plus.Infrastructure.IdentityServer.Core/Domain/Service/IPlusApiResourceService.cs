using Plus.Infrastructure.IdentityServer.Core.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Plus.Infrastructure.IdentityServer.Core.Domain.Service
{
  
    public interface IPlusApiResourceService
    {
        int Insert(ApiResource apiResource);
        int Update(ApiResource apiResource);
        int Delete(int id);
        ApiResource GetById(int id);
        IEnumerable<ApiResource> GetAll();
    }
}