using Microsoft.AspNetCore.Identity;
using Plus.Infrastructure.Core.Domain.Model;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Plus.Infrastructure.IdentityServer.Core.Service
{
    //public class PlusUserClaimsPrincipalFactory : IUserClaimsPrincipalFactory<ApplicationUser>
    //{
    //    public Task<ClaimsPrincipal> CreateAsync(ApplicationUser user)
    //    {
    //        return Task.Factory.StartNew(() =>
    //        {
    //            var identity = new ClaimsIdentity();
    //            identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));
    //            var principle = new ClaimsPrincipal(identity);

    //            return principle;
    //        });
    //    }
    //}
}
