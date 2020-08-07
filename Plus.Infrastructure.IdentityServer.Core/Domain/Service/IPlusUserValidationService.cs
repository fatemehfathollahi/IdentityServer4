using System.Threading.Tasks;

namespace Plus.Infrastructure.IdentityServer.Core.Domain.Service
{
    public interface IPlusUserValidationService
    {
        bool Validate(string userName, string password);
        Task<bool> ValidateAsync(string userName, string password);
    }
}
