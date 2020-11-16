using System;
using System.Linq;
using IdentityServerAspNetIdentity.Data;
using IdentityServerAspNetIdentity.Data.Migrations.Models;
using Microsoft.EntityFrameworkCore;

namespace IdentityServerAspNetIdentity.Services
{
    public class TenantConfigurationService : ITenantCofigurationService
    {
        private readonly ApplicationDbContext applicationDbContext;
        public TenantConfigurationService(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public TenantConfiguration GetTenantConfiguration(string clientId, string domain)
        {
            return this.applicationDbContext.TenantConfigurations.Include(tc => tc.ExternalProviders).Where(tc => tc.ClientId == clientId && tc.Domain.ToLower() == domain.ToLower()).FirstOrDefault();
        }
    }
}
