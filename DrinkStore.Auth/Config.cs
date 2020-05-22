using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrinkStore.Auth
{
    public class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Email(),
                new IdentityResources.Profile(),
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("resourceapi", "Resource API")
                {
                    Scopes = {
                        new Scope("resourceapi:use"),
                    }
                }
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new[]
            {//http://localhost:8080
                new Client {
                    RequireConsent = false,
                    ClientId = "vue_app",
                    ClientName = "Vue APP",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowedScopes = { "openid", "profile", "email", "resourceapi:use"},
                    RedirectUris = { "https://drinkstoreclient.azurewebsites.net/" + "/auth-callback.html" },
                    PostLogoutRedirectUris = {"https://drinkstoreclient.azurewebsites.net/"},
                    AllowedCorsOrigins = {"https://drinkstoreclient.azurewebsites.net"},
                    AllowAccessTokensViaBrowser = true,
                    AccessTokenLifetime = 3600
                }
            };
        }
    }
}
