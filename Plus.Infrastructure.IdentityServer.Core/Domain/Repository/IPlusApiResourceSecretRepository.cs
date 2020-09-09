using Plus.Infrastructure.IdentityServer.Core.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Plus.Infrastructure.IdentityServer.Core.Domain.Repository
{
    public interface IPlusApiResourceSecretRepository
    {
        Task Insert(ApiResourceSecret apiSecret);

        Task Update(ApiResourceSecret apiSecret);

        Task DeleteAll(int resourceId);

        Task Delete(int secretId);

        Task<ApiResourceSecret> GetById(int secretId);

        Task<IEnumerable<ApiResourceSecret>> GetAll();

        Task<IEnumerable<ApiResourceSecret>> GetSecretsByResourceId(int resourceId);
    }
}
