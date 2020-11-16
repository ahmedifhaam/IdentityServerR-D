// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServerAspNetIdentity
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("api1", "My API")
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                   new Client
                {
                    ClientId = "client",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = { "api1" }
                },
                new Client
                {
                    ClientId = "mvc",
                    ClientSecrets = { new Secret("secret".Sha256())},

                    AllowedGrantTypes = GrantTypes.Code,
                    //IdentityProviderRestrictions = new List<string>(){IdentityServerConstants.LocalIdentityProvider },

                    RedirectUris = { "https://localhost:5002/signin-oidc"},
                    PostLogoutRedirectUris = { "https://localhost:5002/signout-callback-oidc"},

                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile
                    }
                },
                new Client
                {
                    ClientId = "mvc2",
                    ClientSecrets = { new Secret("secret2".Sha256())},

                    AllowedGrantTypes = GrantTypes.Code,
                    //IdentityProviderRestrictions = new List<string>(){IdentityServerConstants.LocalIdentityProvider },

                    RedirectUris = { "https://localhost:7002/signin-oidc"},
                    PostLogoutRedirectUris = { "https://localhost:7002/signout-callback-oidc"},

                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile
                    }
                }

        };
    }
}