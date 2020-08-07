using Plus.Infrastructure.Domain.Domain.Service;
using System;
using System.Linq;

namespace Plus.Infrastructure.IdentityServer.Core.Domain
{
    public class PlusAspNetIdentityOptions
    {
        private readonly ISettingService settingService;

        public PlusAspNetIdentityOptions(ISettingService settingService)
        {
            this.settingService = settingService;
        }

        public int PasswordRequiredLength => 6;
        public bool PasswordRequireNonLetterOrDigit => false;
        public bool PasswordRequireDigit => true;
        public bool PasswordRequireLowercase => true;
        public bool PasswordRequireUppercase => true;
        public bool UserLockoutEnabledByDefault => true;
        public TimeSpan DefaultAccountLockoutTimeSpan => TimeSpan.FromMinutes(30);
        public int MaxFailedAccessAttemptsBeforeLockout => 5;
        public static readonly string IdentityProviderName = "PLUS ASP.NET Identity";

        public bool IsPasswordStrongEnough(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return false;
            }

            if (password.Length < PasswordRequiredLength)
            {
                return false;
            }

            if (PasswordRequireNonLetterOrDigit && !password.Any(p => !char.IsLetterOrDigit(p)))
            {
                return false;
            }

            if (PasswordRequireDigit && !password.Any(p => char.IsDigit(p)))
            {
                return false;
            }

            if (PasswordRequireLowercase && !password.Any(p => char.IsLower(p)))
            {
                return false;
            }

            if (PasswordRequireUppercase && !password.Any(p => char.IsUpper(p)))
            {
                return false;
            }

            return true;
        }
        public bool IsPasswordValid(string password, out string message)
        {
            var policy = settingService.GetUserPasswordPolicySetting();
            if (policy.MinimumPasswordLength > password.Length)
            {
                message = $"password can not ";
                return false;
            }

            if (!IsPasswordStrongEnough(password))
            {
                message = "PolicyEnforceComplexPasswordToolTip";
                return false;
            }

            message = string.Empty;
            return true;
        }
    }
}
