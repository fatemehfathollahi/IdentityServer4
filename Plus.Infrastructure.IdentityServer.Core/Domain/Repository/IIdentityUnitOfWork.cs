using System;
using System.Collections.Generic;
using System.Text;

namespace Plus.Infrastructure.IdentityServer.Core.Domain.Repository
{
    public interface IIdentityUnitOfWork:IDisposable
    {
        IPlusClientRepository PlusClientRepository { get; }
        IPlusClientClaimRepository PlusClientClaimRepository { get; }
        IPlusClientGrantTypeRepository PlusClientGrantTypeRepository { get; }
        IPlusClientIdPRestrictionRepository PlusClientIdPRestrictionRepository { get; }
        IPlusClientPostLogoutRedirectUriRepository PlusClientPostLogoutRedirectUriRepository { get; }
        IPlusClientPropertyRepository PlusClientPropertyRepository { get; }
        IPlusClientRedirectUriRepository PlusClientRedirectUriRepository { get; }
        IPlusClientScopeRepository PlusClientScopeRepository { get; }
        IPlusClientSecretRepository PlusClientSecretRepository { get; }
        IPlusClientCorsOriginRepository PlusClientCorsOriginRepository { get; }

        IPlusApiResourceRepository PlusApiResourceRepository { get; }
        IPlusApiResourceScopeRepository PlusApiResourceScopeRepository { get; }
        IPlusApiResourceSecretRepository PlusApiResourceSecretRepository { get; }
        IPlusApiResourcePropertyRepository PlusApiResourcePropertyRepository { get; }
        IPlusApiResourceClaimRepository PlusApiResourceClaimRepository { get; }

        void Save();
    }
}
