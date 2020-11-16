using System;
using IdentityServerAspNetIdentity.Data.Migrations.Models;

namespace IdentityServerAspNetIdentity.Services
{
    public interface ITenantCofigurationService
    {
        public TenantConfiguration GetTenantConfiguration(string clientId, string domain);
    }
}
