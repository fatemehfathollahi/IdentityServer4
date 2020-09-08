using Plus.Infrastructure.IdentityServer.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Plus.Infrastructure.IdentityServer.Core.Domain.Repository
{
    public  interface IPlusClientIdPRestrictionRepository //: IDisposable
    {
        void Insert(ClientIdPRestriction clientIdPRestriction);

        void Update(ClientIdPRestriction clientIdPRestriction);

        void DeleteAll(int clientId);

        void Delete(int clientIdPRestrictionId);

        ClientIdPRestriction GetById(int clientIdPRestrictionId);

        IEnumerable<ClientIdPRestriction> GetAll();

        IEnumerable<ClientIdPRestriction> GetClientIdPRestrictionsByClientId(int clientId);
    }
}
