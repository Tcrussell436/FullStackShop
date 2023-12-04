using Duende.IdentityServer.Models;

namespace FullStackShop.IdentityServer;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResources.Email()
        };

    public static IEnumerable<ApiScope> ApiScopes =>
        new ApiScope[]
        {
            //new ApiScope("scope1"),
            //new ApiScope("scope2"),
        };

    public static IEnumerable<Client> Clients =>
        new Client[]
        {
            // interactive client using code flow + pkce
            new Client
            {
                ClientId = "fss-nuxt",
                // TODO: Default secret, could generate Guid or provide secret from external source
                ClientSecrets = { new Secret("49C1A7E1-0C79-4A89-A3D6-A37998FB86B0".Sha256()) },

                AllowedGrantTypes = GrantTypes.Code,

                RedirectUris =
                {
                    "https://fullstackshop.nuxt:7000/signin-callback",
                    "https://fullstackshop.nuxt:7000/"
                },
                FrontChannelLogoutUri = "https://fullstackshop.nuxt:7000/signout-oidc",
                PostLogoutRedirectUris = { "https://fullstackshop.nuxt:7000/" },
                AllowedCorsOrigins = new [] { "https://fullstackshop.nuxt:7000" },
                AllowOfflineAccess = true,
                AllowedScopes = { "openid", "profile", "email" }
            },
        };
}
