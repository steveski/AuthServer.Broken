// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace Perigee.AuthServer;

using IdentityServer4.Models;
using System.Collections.Generic;
using IdentityServer4;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        new List<IdentityResource>
        { 
            new IdentityResources.OpenId(),
            new IdentityResources.Profile()
        };

    public static IEnumerable<ApiScope> ApiScopes =>
        new List<ApiScope>
        {
            new("api1", "Test Api 1 Scope")
        };

    public static IEnumerable<Client> Clients =>
        new List<Client>
        {
            new Client
            {
                ClientId = "testclient",

                // No interactive user, use the client / secret for authentication
                AllowedGrantTypes = GrantTypes.ClientCredentials,

                // Secret for authentication
                ClientSecrets =
                {
                    new Secret("some_secret".Sha256())
                },

                // Scopes that the client has access to
                AllowedScopes = { "api1" }

            },
            new Client
            {
                ClientId = "mvctestclient",
                ClientSecrets =
                {
                    new Secret("some_mvc_secret".Sha256())
                },

                AllowedGrantTypes = GrantTypes.Code,

                // Where to redirect to after login
                RedirectUris = { "https://localhost:5001/signin-oidc"},

                // Where to redirect to after logout
                PostLogoutRedirectUris = { "https://localhost:5001/signout-callback-oidc" },

                AllowedScopes = new List<string>
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile
                }

            }
        };
}
