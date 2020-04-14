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
                        new Scope("cat"),
                        new Scope("product"),
                        new Scope("order"),
                        new Scope("order:create"),
                        new Scope("order:read"),
                    }
                }
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new[]
            {
                new Client {
                    RequireConsent = false,
                    ClientId = "vue_app",
                    ClientName = "Vue APP",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowedScopes = { "openid", "profile", "email", "cat", "product", "order", "order:create", "order:read"},
                    RedirectUris = {"http://localhost:8080/auth-callback.html"},
                    PostLogoutRedirectUris = {"http://localhost:8080/"},
                    AllowedCorsOrigins = {"http://localhost:8080"},
                    AllowAccessTokensViaBrowser = true,
                    AccessTokenLifetime = 3600
                }
            };
        }
    }
}
