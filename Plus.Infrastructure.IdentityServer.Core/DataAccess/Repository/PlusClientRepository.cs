using Microsoft.EntityFrameworkCore;
using Plus.Infrastructure.IdentityServer.Core.DataAccess.DataContext;
using Plus.Infrastructure.IdentityServer.Core.Domain.Models;
using Plus.Infrastructure.IdentityServer.Core.Domain.Repository;
using Plus.Infrastructure.IdentityServer.Core.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Plus.Infrastructure.IdentityServer.Core.DataAccess.Repository
{
    public class PlusClientRepository : IPlusClientRepository
    {
        private readonly PlusConfigurationDbContext plusDataContext;
        public PlusClientRepository(PlusConfigurationDbContext plusDataContext)
        {
            this.plusDataContext = plusDataContext;
        }

        public IEnumerable<Client> GetAll()
        {
            return plusDataContext.Clients.ToModel().ToList();
        }

        public Client GetByClientId(string clientId)
        {
            return plusDataContext.Clients.ToModel().Single(c => c.ClientId.Equals(clientId));
        }

        public void Insert(Client client)
        {
            plusDataContext.Entry(client).State = EntityState.Added;
            plusDataContext.Clients.Add(client.ToEntity());
            plusDataContext.SaveChanges();
        }

        public void Update(Client client)
        {
            plusDataContext.Clients.Update(client.ToEntity());
            plusDataContext.SaveChanges();
        }
    }
}
