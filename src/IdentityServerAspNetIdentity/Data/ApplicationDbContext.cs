using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using IdentityServerAspNetIdentity.Models;
using IdentityServerAspNetIdentity.Data.Migrations.Models;
using IdentityServerHost.Quickstart.UI;
using System.Collections.Generic;
using System;

namespace IdentityServerAspNetIdentity.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<TenantConfiguration> TenantConfigurations { get; set; }
        public DbSet<Migrations.Models.ExternalProvider> ExternalProviders { get;  set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Migrations.Models.ExternalProvider>().HasMany<TenantConfiguration>();
            //builder.Entity<TenantConfiguration>().HasMany<Migrations.Models.ExternalProvider>().W;
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
