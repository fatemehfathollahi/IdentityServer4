using IdentityModel;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Plus.Infrastructure.Core.Domain.Service;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Plus.Infrastructure.IdentityServerClient
{
    internal class PlusOpenIdConnectPostConfigureOptions : IPostConfigureOptions<OpenIdConnectOptions>
    {
        private readonly IDomainService domainService;
        public PlusOpenIdConnectPostConfigureOptions(IDomainService domainService)
        {
            this.domainService = domainService;
        }

        public void PostConfigure(string name, OpenIdConnectOptions options)
        {
            var domainInfo = domainService.GetDomainInfo();

            options.Authority = domainInfo.IdentiyServerUrl;
            options.RequireHttpsMetadata = domainInfo.Scheme.Equals(Constant.HTTPS, System.StringComparison.InvariantCultureIgnoreCase);
            options.ClientId = Constant.ClientId;
            options.ClientSecret = Constant.ClientSecret;
            options.ResponseType = Constant.OpenIdConnectResponseType;
            options.Scope.Add(Constant.Scope);
            options.SaveTokens = true;
            options.Events.OnRedirectToIdentityProvider = context =>
            {
                if (context.ProtocolMessage.RequestType == OpenIdConnectRequestType.Authentication)
                {
                    var codeVerifier = CryptoRandom.CreateUniqueId(32);
                    context.Properties.Items.Add(Constant.OpenIdConnectEventsRedirectToIdentityProviderProperties, codeVerifier);
                    string codeChallenge;
                    using (var sha256 = SHA256.Create())
                    {
                        var challengeBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(codeVerifier));
                        codeChallenge = Base64Url.Encode(challengeBytes);
                    }

                    context.ProtocolMessage.Parameters.Add(Constant.OpenIdConnectEventsRedirectToIdentityProviderProtocolMessageParameterCodeChallenge, codeChallenge);
                    context.ProtocolMessage.Parameters.Add(Constant.OpenIdConnectEventsRedirectToIdentityProviderProtocolMessageParameterCodeChallengeMethod, Constant.OpenIdConnectEventsRedirectToIdentityProviderProtocolMessageParameterCodeChallengeMethodValue);
                }

                return Task.CompletedTask;
            };
            options.Events.OnAuthorizationCodeReceived = context =>
            {
                if (context.TokenEndpointRequest?.GrantType == OpenIdConnectGrantTypes.AuthorizationCode)
                {
                    if (context.Properties.Items.TryGetValue(Constant.OpenIdConnectEventsRedirectToIdentityProviderProperties, out var codeVerifier))
                    {
                        context.TokenEndpointRequest.Parameters.Add(Constant.OpenIdConnectEventsRedirectToIdentityProviderProperties, codeVerifier);
                    }
                }

                return Task.CompletedTask;
            };
        }
    }
}
