using Plus.Infrastructure.IdentityServer.Core.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Plus.Infrastructure.IdentityServer.Core.Domain.Repository
{
    public interface IPlusClientSecretRepository
    {
        Task Insert(ClientSecret clientSecret);

        Task Update(ClientSecret clientSecret);

        Task DeleteAll(int clientId);

        Task Delete(int secretId);

        Task<ClientSecret> GetById(int secretId);

        Task<IEnumerable<ClientSecret>> GetAll();

        Task<IEnumerable<ClientSecret>> GetSecretsByClientId(int clientId);

    }
}
