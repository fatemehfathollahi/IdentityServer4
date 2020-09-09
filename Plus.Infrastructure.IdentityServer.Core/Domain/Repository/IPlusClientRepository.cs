using Plus.Infrastructure.IdentityServer.Core.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Plus.Infrastructure.IdentityServer.Core.Domain.Repository
{
    public interface IPlusClientRepository
    {
        Task<int> Insert(Client client);

        Task<int> Update(Client client);

        Task Delete(int id);

        Task<Client> GetById(int id);

        Task<IEnumerable<Client>> GetAll();
    }
}
