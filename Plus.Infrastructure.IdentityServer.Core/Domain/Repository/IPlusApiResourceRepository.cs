using Plus.Infrastructure.IdentityServer.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Plus.Infrastructure.IdentityServer.Core.Domain.Repository
{
    public interface IPlusApiResourceRepository: IDisposable
    {
        int Insert(ApiResource apiResource);

        int Update(ApiResource apiResource);

        int Delete(int id);

        ApiResource GetById(int id);

        IEnumerable<ApiResource> GetAll();
    }
}
