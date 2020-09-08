using Plus.Infrastructure.IdentityServer.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Plus.Infrastructure.IdentityServer.Core.Domain.Repository
{
    public interface IPlusClientPropertyRepository//:IDisposable
    {
        void Insert(ClientProperty clientProperty);

        void Update(ClientProperty clientProperty);

        void Delete(int propertyId);

        void DeleteAll(int clientId);

        ClientProperty GetById(int propertyId);

        IEnumerable<ClientProperty> GetAll();

        IEnumerable<ClientProperty> GetPropertiesByClientId(int clientId);
    }
}
