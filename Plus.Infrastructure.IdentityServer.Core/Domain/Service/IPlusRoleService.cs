using System;
using System.Collections.Generic;

namespace Plus.Infrastructure.IdentityServer.Core.Domain.Service
{
    public interface IPlusRoleService
    {
        IList<string> GetRoles(Guid userId);
        IList<string> GetRoles(string username);
        bool IsUserInRole(string username, string role);
    }
}
