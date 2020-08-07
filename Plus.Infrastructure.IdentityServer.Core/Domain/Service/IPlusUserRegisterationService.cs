using Plus.Infrastructure.Domain.Domain.Model;
using System;

namespace Plus.Infrastructure.IdentityServer.Core.Domain.Service
{
    public interface IPlusUserRegisterationService
    {
        void Save(PlusUser user, bool savePoint = false);
        bool ActivateUserViaEmail(Guid userId);
        void ActivateUser(PlusUser user);
        bool IsUserLimitExceeded();
        void DeactivateUser(PlusUser user);
        PlusUser GetActiveUserById(Guid userId);
    }
}
