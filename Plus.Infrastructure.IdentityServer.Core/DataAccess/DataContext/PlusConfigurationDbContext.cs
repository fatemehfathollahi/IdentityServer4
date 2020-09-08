using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using Plus.Infrastructure.Core.Domain.Service;
using Plus.Infrastructure.IdentityServer.Core.Domain.Models;
using Entities = IdentityServer4.EntityFramework.Entities;
using System.Threading.Tasks;

namespace Plus.Infrastructure.IdentityServer.Core.DataAccess.DataContext
{
    public class PlusConfigurationDbContext : ConfigurationDbContext
    {
        private readonly IDomainService domainService;
        public PlusConfigurationDbContext(DbContextOptions<ConfigurationDbContext> options,
            ConfigurationStoreOptions storeOptions,
            IDomainService domainService)
            : base(options, storeOptions)
        {
            this.domainService = domainService;
        }


        public DbSet<Entities.ApiResourceScope> ApiResourceScopes { get; set; }

        public DbSet<Entities.ApiResourceSecret> ApiResourceSecrets { get; set; }

        public DbSet<Entities.ApiResourceClaim> ApiResourceClaims { get; set; }

        public DbSet<Entities.ApiResourceProperty> ApiResourceProperties { get; set; }

        public DbSet<Entities.ClientIdPRestriction> ClientIdPRestrictions { get; set; }

        public DbSet<Entities.ClientClaim> ClientClaims { get; set; }

        public DbSet<Entities.ClientProperty> ClientProperties { get; set; }

        public DbSet<Entities.ClientScope> ClientScopes { get; set; }

        public DbSet<Entities.ClientSecret> ClientSecret { get; set; }

        public DbSet<Entities.ClientGrantType> ClientGrantTypes { get; set; }

        public DbSet<Entities.ClientRedirectUri> ClientRedirectUris { get; set; }

        public DbSet<Entities.ClientPostLogoutRedirectUri> ClientPostLogoutRedirectUris { get; set; }



        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Client>(client =>
        //    {
        //        client.ToTable("Clients");
        //        client.HasKey(x => x.Id);

        //        client.Property(x => x.ClientId).HasMaxLength(200).IsRequired();
        //        client.Property(x => x.ProtocolType).HasMaxLength(200).IsRequired();
        //        client.Property(x => x.ClientName).HasMaxLength(200);
        //        client.Property(x => x.ClientUri).HasMaxLength(2000);
        //        client.Property(x => x.LogoUri).HasMaxLength(2000);
        //        client.Property(x => x.Description).HasMaxLength(1000);
        //        client.Property(x => x.FrontChannelLogoutUri).HasMaxLength(2000);
        //        client.Property(x => x.BackChannelLogoutUri).HasMaxLength(2000);
        //        client.Property(x => x.ClientClaimsPrefix).HasMaxLength(200);
        //        client.Property(x => x.PairWiseSubjectSalt).HasMaxLength(200);
        //        client.Property(x => x.UserCodeType).HasMaxLength(100);

        //        client.HasIndex(x => x.ClientId).IsUnique();

        //        client.HasMany(x => x.AllowedGrantTypes).WithOne(x => x.Client).HasForeignKey(x => x.ClientId).IsRequired().OnDelete(DeleteBehavior.Cascade);
        //        client.HasMany(x => x.RedirectUris).WithOne(x => x.Client).HasForeignKey(x => x.ClientId).IsRequired().OnDelete(DeleteBehavior.Cascade);
        //        client.HasMany(x => x.PostLogoutRedirectUris).WithOne(x => x.Client).HasForeignKey(x => x.ClientId).IsRequired().OnDelete(DeleteBehavior.Cascade);
        //        client.HasMany(x => x.AllowedScopes).WithOne(x => x.Client).HasForeignKey(x => x.ClientId).IsRequired().OnDelete(DeleteBehavior.Cascade);
        //        client.HasMany(x => x.ClientSecrets).WithOne(x => x.Client).HasForeignKey(x => x.ClientId).IsRequired().OnDelete(DeleteBehavior.Cascade);
        //        client.HasMany(x => x.Claims).WithOne(x => x.Client).HasForeignKey(x => x.ClientId).IsRequired().OnDelete(DeleteBehavior.Cascade);
        //        client.HasMany(x => x.IdentityProviderRestrictions).WithOne(x => x.Client).HasForeignKey(x => x.ClientId).IsRequired().OnDelete(DeleteBehavior.Cascade);
        //        client.HasMany(x => x.AllowedCorsOrigins).WithOne(x => x.Client).HasForeignKey(x => x.ClientId).IsRequired().OnDelete(DeleteBehavior.Cascade);
        //        client.HasMany(x => x.Properties).WithOne(x => x.Client).HasForeignKey(x => x.ClientId).IsRequired().OnDelete(DeleteBehavior.Cascade);
        //    });

        //    modelBuilder.Entity<ClientGrantType>(grantType =>
        //    {
        //        grantType.ToTable("ClientGrantTypes");
        //        grantType.Property(x => x.GrantType).HasMaxLength(250).IsRequired();
        //    });

        //    modelBuilder.Entity<ClientRedirectUri>(redirectUri =>
        //    {
        //        redirectUri.ToTable("ClientRedirectUris");
        //        redirectUri.Property(x => x.RedirectUri).HasMaxLength(2000).IsRequired();
        //    });

        //    modelBuilder.Entity<ClientPostLogoutRedirectUri>(postLogoutRedirectUri =>
        //    {
        //        postLogoutRedirectUri.ToTable("ClientPostLogoutRedirectUris");
        //        postLogoutRedirectUri.Property(x => x.PostLogoutRedirectUri).HasMaxLength(2000).IsRequired();
        //    });

        //    modelBuilder.Entity<ClientScope>(scope =>
        //    {
        //        scope.ToTable("ClientScopes");
        //        scope.Property(x => x.Scope).HasMaxLength(200).IsRequired();
        //    });

        //    modelBuilder.Entity<ClientSecret>(secret =>
        //    {
        //        secret.ToTable("ClientSecrets");
        //        secret.Property(x => x.Value).HasMaxLength(4000).IsRequired();
        //        secret.Property(x => x.Type).HasMaxLength(250).IsRequired();
        //        secret.Property(x => x.Description).HasMaxLength(2000);
        //    });

        //    modelBuilder.Entity<ClientClaim>(claim =>
        //    {
        //        claim.ToTable("ClientClaims");
        //        claim.Property(x => x.Type).HasMaxLength(250).IsRequired();
        //        claim.Property(x => x.Value).HasMaxLength(250).IsRequired();
        //    });

        //    modelBuilder.Entity<ClientIdPRestriction>(idPRestriction =>
        //    {
        //        idPRestriction.ToTable("ClientIdPRestrictions");
        //        idPRestriction.Property(x => x.Provider).HasMaxLength(200).IsRequired();
        //    });

        //    modelBuilder.Entity<ClientCorsOrigin>(corsOrigin =>
        //    {
        //        corsOrigin.ToTable("ClientCorsOrigins");
        //        corsOrigin.Property(x => x.Origin).HasMaxLength(150).IsRequired();
        //    });

        //    modelBuilder.Entity<ClientProperty>(property =>
        //    {
        //        property.ToTable("ClientPropertis");
        //        property.Property(x => x.Key).HasMaxLength(250).IsRequired();
        //        property.Property(x => x.Value).HasMaxLength(2000).IsRequired();
        //    });

        //    modelBuilder.Entity<IdentityResource>(identityResource =>
        //    {
        //        identityResource.ToTable("IdentityResources").HasKey(x => x.Id);

        //        identityResource.Property(x => x.Name).HasMaxLength(200).IsRequired();
        //        identityResource.Property(x => x.DisplayName).HasMaxLength(200);
        //        identityResource.Property(x => x.Description).HasMaxLength(1000);

        //        identityResource.HasIndex(x => x.Name).IsUnique();

        //        identityResource.HasMany(x => x.UserClaims).WithOne(x => x.IdentityResource).HasForeignKey(x => x.IdentityResourceId).IsRequired().OnDelete(DeleteBehavior.Cascade);
        //        identityResource.HasMany(x => x.Properties).WithOne(x => x.IdentityResource).HasForeignKey(x => x.IdentityResourceId).IsRequired().OnDelete(DeleteBehavior.Cascade);
        //    });

        //    modelBuilder.Entity<IdentityClaim>(claim =>
        //    {
        //        claim.ToTable("IdentityClaims").HasKey(x => x.Id);

        //        claim.Property(x => x.Type).HasMaxLength(200).IsRequired();
        //    });

        //    modelBuilder.Entity<IdentityResourceProperty>(property =>
        //    {
        //        property.ToTable("IdentityResourceProperties");
        //        property.Property(x => x.Key).HasMaxLength(250).IsRequired();
        //        property.Property(x => x.Value).HasMaxLength(2000).IsRequired();
        //    });

        //    modelBuilder.Entity<ApiResource>(apiResource =>
        //    {
        //        apiResource.ToTable("ApiResources").HasKey(x => x.Id);

        //        apiResource.Property(x => x.Name).HasMaxLength(200).IsRequired();
        //        apiResource.Property(x => x.DisplayName).HasMaxLength(200);
        //        apiResource.Property(x => x.Description).HasMaxLength(1000);

        //        apiResource.HasIndex(x => x.Name).IsUnique();

        //        apiResource.HasMany(x => x.Secrets).WithOne(x => x.ApiResource).HasForeignKey(x => x.ApiResourceId).IsRequired().OnDelete(DeleteBehavior.Cascade);
        //        apiResource.HasMany(x => x.Scopes).WithOne(x => x.ApiResource).HasForeignKey(x => x.ApiResourceId).IsRequired().OnDelete(DeleteBehavior.Cascade);
        //        apiResource.HasMany(x => x.UserClaims).WithOne(x => x.ApiResource).HasForeignKey(x => x.ApiResourceId).IsRequired().OnDelete(DeleteBehavior.Cascade);
        //        apiResource.HasMany(x => x.Properties).WithOne(x => x.ApiResource).HasForeignKey(x => x.ApiResourceId).IsRequired().OnDelete(DeleteBehavior.Cascade);
        //    });

        //    modelBuilder.Entity<ApiSecret>(apiSecret =>
        //    {
        //        apiSecret.ToTable("ApiSecrets").HasKey(x => x.Id);

        //        apiSecret.Property(x => x.Description).HasMaxLength(1000);
        //        apiSecret.Property(x => x.Value).HasMaxLength(4000).IsRequired();
        //        apiSecret.Property(x => x.Type).HasMaxLength(250).IsRequired();
        //    });

        //    modelBuilder.Entity<ApiResourceClaim>(apiClaim =>
        //    {
        //        apiClaim.ToTable("ApiClaims").HasKey(x => x.Id);

        //        apiClaim.Property(x => x.Type).HasMaxLength(200).IsRequired();
        //    });

        //    modelBuilder.Entity<ApiScope>(apiScope =>
        //    {
        //        apiScope.ToTable("ApiScopes").HasKey(x => x.Id);

        //        apiScope.Property(x => x.Name).HasMaxLength(200).IsRequired();
        //        apiScope.Property(x => x.DisplayName).HasMaxLength(200);
        //        apiScope.Property(x => x.Description).HasMaxLength(1000);

        //        apiScope.HasIndex(x => x.Name).IsUnique();

        //        apiScope.HasMany(x => x.UserClaims).WithOne(x => x.ApiScope).HasForeignKey(x => x.ApiScopeId).IsRequired().OnDelete(DeleteBehavior.Cascade);
        //    });

        //    modelBuilder.Entity<ApiScopeClaim>(apiScopeClaim =>
        //    {
        //        apiScopeClaim.ToTable("ApiScopeClaims").HasKey(x => x.Id);

        //        apiScopeClaim.Property(x => x.Type).HasMaxLength(200).IsRequired();
        //    });

        //    modelBuilder.Entity<ApiResourceProperty>(property =>
        //    {
        //        property.ToTable("ApiResourcePropertis");
        //        property.Property(x => x.Key).HasMaxLength(250).IsRequired();
        //        property.Property(x => x.Value).HasMaxLength(2000).IsRequired();
        //    });


        //    base.OnModelCreating(modelBuilder);
        //}


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(domainService.GetDomainInfo().ConnectionString)
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            base.OnConfiguring(optionsBuilder);
        }

    }
}
