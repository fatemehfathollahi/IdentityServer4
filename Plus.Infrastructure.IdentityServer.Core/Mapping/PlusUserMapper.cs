using Plus.Infrastructure.Core.Domain.Model;
using Plus.Infrastructure.Domain.Domain.Model;

namespace Plus.Infrastructure.IdentityServer.Core.Mapping
{
    internal static class PlusUserMapper
    {
        internal static ApplicationUser ToApplicationUser(this PlusUser source)
        {
            if (source == null)
            {
                return null;
            }

            return new ApplicationUser()
            {
                AccessFailedCount = source.AccessFailedCount,
                ActivationDate = source.ActivationDate,
                AuthenticationUserType = Infrastructure.Core.Domain.Enumeration.UserType.Operator,
                CommissionPercent = source.CommissionPercent,
                EmailConfirmed = source.EmailConfirmed,
                Id = source.SecurityItemId,
                IdentityId = source.IdentityId,
                IsActive = true,
                IsSystemUser = source.IsSystemUser,
                LastLockDate = source.LastLockDate,
                LastLoginDate = source.LastLoginDate,
                LastPasswordChangeDate = source.LastPasswordChangeDate,
                LastSuspendDate = source.LastSuspendDate,
                LockoutEnabled = source.LockoutEnabled,
                LockoutEndDateUtc = source.LockoutEndDateUtc,
                Logo = source.Logo,
                Password = source.Password,
                PasswordNeverExpires = source.PasswordNeverExpires,
                PhoneNumberConfirmed = source.PhoneNumberConfirmed,
                ProfileTypeIndex = Infrastructure.Core.Domain.Enumeration.Gp_ProfileType.Operator,
                SecurityItemId = source.SecurityItemId,
                SecurityStamp = source.SecurityStamp,
                TelephonyPassword = source.TelephonyPassword,
                TempEmail = source.TempEmail,
                TwoFactorEnabled = source.TwoFactorEnabled,
                UserName = source.UserName,
                UserTypeIndex = Infrastructure.Core.Domain.Enumeration.UserType.Operator,
            };
        }
    }
}
