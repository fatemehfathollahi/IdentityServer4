using Microsoft.EntityFrameworkCore;
using Plus.Infrastructure.IdentityServer.Core.DataAccess.DataContext;
using Plus.Infrastructure.IdentityServer.Core.Domain.Models;
using Plus.Infrastructure.IdentityServer.Core.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Plus.Infrastructure.IdentityServer.Core.DataAccess.Repository
{
    public class PlusClientRepository : IPlusClientRepository
    {
        private readonly PlusIdentityConfigurationDbContext plusDataContext;
        public PlusClientRepository(PlusIdentityConfigurationDbContext plusDataContext)
        {
            this.plusDataContext = plusDataContext;
        }

        public IEnumerable<Client> GetAll()
        {
            return plusDataContext.Clients.ToList();
        }

        public Client GetByClientId(string clientId)
        {
            return plusDataContext.Clients.Single(c => c.ClientId.Equals(clientId));//TODO
        }

        public void Insert(Client client)
        {
            plusDataContext.Entry(client).State = EntityState.Added;
            plusDataContext.Clients.Add(client);
            plusDataContext.SaveChanges();
        }

        public void Update(Client client)
        {
            plusDataContext.Clients.Update(client);
            plusDataContext.SaveChanges();
        }
    }
}
