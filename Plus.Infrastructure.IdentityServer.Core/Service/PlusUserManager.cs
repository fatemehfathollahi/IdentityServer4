using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Plus.Infrastructure.Core.Domain.Model;
using Plus.Infrastructure.Domain.Domain.Model;
using Plus.Infrastructure.Domain.Domain.Service;
using Plus.Infrastructure.IdentityServer.Core.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Plus.Infrastructure.IdentityServer.Core.Service
{
    public class PlusUserManager : UserManager<ApplicationUser>
    {
        private readonly ISettingService settingService;
        private readonly IUserService userService;
        IPasswordHasher<ApplicationUser> passwordHasher;

        public PlusUserManager(IUserStore<ApplicationUser> store, IOptions<IdentityOptions> optionsAccessor,
                                IPasswordHasher<ApplicationUser> passwordHasher, IEnumerable<IUserValidator<ApplicationUser>> userValidators,
                                IEnumerable<IPasswordValidator<ApplicationUser>> passwordValidators, ILookupNormalizer keyNormalizer,
                                IdentityErrorDescriber errors, IServiceProvider services, ILogger<UserManager<ApplicationUser>> logger,
                                ISettingService settingService,
                                        IUserService userService)
            : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
        {
            this.settingService = settingService;
            this.userService = userService;
            this.passwordHasher = passwordHasher;
        }


        public IList<string> GetRoles(Guid userId)
        {
            var store = (Store as PlusUserStore);
            var user = store.FindById(userId);
            return store.GetRoles(user);
        }
        public IList<string> GetRoles(string username)
        {
            var store = (Store as PlusUserStore);
            var user = store.FindByName(username);
            return store.GetRoles(user);
        }
        public bool IsUserInRole(string username, string role)
        {
            return GetRoles(username).Contains(role);
        }
        public void Save(PlusUser user, bool savePoint = false)
        {
            throw new NotImplementedException();
        }
        public bool ActivateUserViaEmail(Guid userId)
        {
            throw new NotImplementedException();
        }
        public void ActivateUser(PlusUser user)
        {
            throw new NotImplementedException();
        }
        public bool IsUserLimitExceeded()
        {
            throw new NotImplementedException();
        }
        public void DeactivateUser(PlusUser user)
        {
            throw new NotImplementedException();
        }
        public PlusUser GetActiveUserById(Guid userId)
        {
            return userService.GetActiveUserById(userId);
        }
        public bool CheckPasswordIsExpired(string username)
        {
            return CheckPasswordIsExpired((Store as PlusUserStore).FindByName(username));
        }
        public bool CheckPasswordIsExpired(ApplicationUser entity)
        {
            var policy = settingService.GetUserPasswordPolicySetting();
            if (policy.MaximumPasswordAge > 0 &&
                (entity.LastPasswordChangeDate ?? DateTime.MinValue) < DateTime.Now.AddDays(-policy.MaximumPasswordAge) &&
                    !entity.PasswordNeverExpires)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<bool> ResetToNewPasswordAsync(Guid userId, string newPassword)
        {
            if (!new PlusAspNetIdentityOptions(settingService).IsPasswordStrongEnough(newPassword))
            {
                return false;
            }

            var user = await FindByIdAsync(userId.ToString());

            string newPasswordHash = passwordHasher.HashPassword(user, newPassword);
            await (Store as PlusUserStore).SetPasswordHashAsync(user, newPasswordHash);
            return true;
        }

    }
}
