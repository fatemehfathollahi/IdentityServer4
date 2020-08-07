namespace Plus.Infrastructure.IdentityServerClient
{
    internal static class Constant
    {
        internal static readonly string AuthenticationDefaultScheme = "Cookies";
        internal static readonly string AuthenticationDefaultChallengeScheme = "oidc";
        internal static readonly string CookieName = "Cookies";
        internal static readonly string OpenIdConnectName = "oidc";
        internal static readonly string ClientId = "client";
        internal static readonly string ClientSecret = "secret";
        internal static readonly string Scope = "api1";
        internal static readonly string OpenIdConnectResponseType = "code id_token";

        internal static readonly string OpenIdConnectEventsRedirectToIdentityProviderProperties = "code_verifier";
        internal static readonly string OpenIdConnectEventsRedirectToIdentityProviderProtocolMessageParameterCodeChallenge = "code_challenge";
        internal static readonly string OpenIdConnectEventsRedirectToIdentityProviderProtocolMessageParameterCodeChallengeMethod = "code_challenge_method";
        internal static readonly string OpenIdConnectEventsRedirectToIdentityProviderProtocolMessageParameterCodeChallengeMethodValue = "S256";
        internal static readonly string HTTPS = "https";
    }
}
