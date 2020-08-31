using Plus.Infrastructure.IdentityServer.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Plus.Infrastructure.IdentityServer.Core.Domain.Repository
{
    public interface IPlusApiResourceRepository: IDisposable
    {
        void Insert(ApiResource apiResource);

        void Update(ApiResource apiResource);

        void Delete(int id);

        ApiResource GetById(int id);

        IEnumerable<ApiResource> GetAll();
    }
}
