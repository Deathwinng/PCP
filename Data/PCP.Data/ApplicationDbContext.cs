﻿namespace PCP.Data
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using PCP.Data.Common.Models;
    using PCP.Data.Models;
    using PCP.Data.Models.Case;
    using PCP.Data.Models.CPU;
    using PCP.Data.Models.CPUCooler;
    using PCP.Data.Models.Drive;
    using PCP.Data.Models.GPU;
    using PCP.Data.Models.Memory;
    using PCP.Data.Models.Motherboard;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        private static readonly MethodInfo SetIsDeletedQueryFilterMethod =
            typeof(ApplicationDbContext).GetMethod(
                nameof(SetIsDeletedQueryFilter),
                BindingFlags.NonPublic | BindingFlags.Static);

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<CPU> CPUs { get; set; }

        public DbSet<CPUUserRating> CPUUserRatings { get; set; }

        public DbSet<Socket> Sockets { get; set; }

        public DbSet<CoreName> CoreNames { get; set; }

        public DbSet<Series> Series { get; set; }

        public DbSet<MemoryType> MemoryTypes { get; set; }

        public DbSet<MemorySpeed> MemorySpeeds { get; set; }

        public DbSet<Brand> Brands { get; set; }

        public DbSet<Lithography> Lithographies { get; set; }

        public DbSet<IntegratedGraphic> IntegratedGraphics { get; set; }

        public DbSet<Motherboard> Motherboards { get; set; }

        public DbSet<MotherboardUserRating> MotherboardUserRatings { get; set; }

        public DbSet<MotherboardMemoryType> MotherboardMemoryTypes { get; set; }

        public DbSet<MothrboardChipset> MothrboardChipset { get; set; }

        public DbSet<LanChipset> LanChipsets { get; set; }

        public DbSet<AudioChipset> AudioChipsets { get; set; }

        public DbSet<FormFactor> FormFactors { get; set; }

        public DbSet<GPU> GPUs { get; set; }

        public DbSet<GPUUserRating> GPUUserRatings { get; set; }

        public DbSet<GPUChipset> GPUChipsets { get; set; }

        public DbSet<GPUCore> GPUCores { get; set; }

        public DbSet<Interface> Interfaces { get; set; }

        public DbSet<Port> Ports { get; set; }

        public DbSet<GPUPort> GPUPorts { get; set; }

        public DbSet<Memory> Memories { get; set; }

        public DbSet<MemoryUserRating> MemoryUserRatings { get; set; }

        public DbSet<HDD> HDDs { get; set; }

        public DbSet<HDDUserRating> HDDUserRatings { get; set; }

        public DbSet<SSD> SSDs { get; set; }

        public DbSet<SSDUserRating> SSDUserRatings { get; set; }

        public DbSet<MemoryComponent> MemoryComponents { get; set; }

        public DbSet<DiskForUsage> Usages { get; set; }

        public DbSet<CPUAirCooler> CPUAirCoolers { get; set; }

        public DbSet<CPUAirCoolerUserRating> CPUAirCoolerUserRatings { get; set; }

        public DbSet<CoolerType> CoolerTypes { get; set; }

        public DbSet<CPUAirCoolerSocket> CPUAirCoolerSockets { get; set; }

        public DbSet<CoolerBearingType> CoolerBearingTypes { get; set; }

        public DbSet<CoolerLEDType> CoolerLEDTypes { get; set; }

        public DbSet<Case> Cases { get; set; }

        public DbSet<CaseUserRating> CaseUserRatings { get; set; }

        public DbSet<CaseFormFactor> CaseFormFactors { get; set; }

        public DbSet<CaseMaterial> CaseMaterials { get; set; }

        public DbSet<CaseType> CaseTypes { get; set; }

        public DbSet<Color> Colors { get; set; }

        public DbSet<Material> Materials { get; set; }

        public DbSet<Setting> Settings { get; set; }

        public override int SaveChanges() => this.SaveChanges(true);

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
            this.SaveChangesAsync(true, cancellationToken);

        public override Task<int> SaveChangesAsync(
            bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = default)
        {
            this.ApplyAuditInfoRules();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Needed for Identity models configuration
            base.OnModelCreating(builder);

            this.ConfigureUserIdentityRelations(builder);

            EntityIndexesConfiguration.Configure(builder);

            var entityTypes = builder.Model.GetEntityTypes().ToList();

            // Set global query filter for not deleted entities only
            var deletableEntityTypes = entityTypes
                .Where(et => et.ClrType != null && typeof(IDeletableEntity).IsAssignableFrom(et.ClrType));
            foreach (var deletableEntityType in deletableEntityTypes)
            {
                var method = SetIsDeletedQueryFilterMethod.MakeGenericMethod(deletableEntityType.ClrType);
                method.Invoke(null, new object[] { builder });
            }

            // Disable cascade delete
            var foreignKeys = entityTypes
                .SelectMany(e => e.GetForeignKeys().Where(f => f.DeleteBehavior == DeleteBehavior.Cascade));
            foreach (var foreignKey in foreignKeys)
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }

        private static void SetIsDeletedQueryFilter<T>(ModelBuilder builder)
            where T : class, IDeletableEntity
        {
            builder.Entity<T>().HasQueryFilter(e => !e.IsDeleted);
        }

        // Applies configurations
        private void ConfigureUserIdentityRelations(ModelBuilder builder)
             => builder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);

        private void ApplyAuditInfoRules()
        {
            var changedEntries = this.ChangeTracker
                .Entries()
                .Where(e =>
                    e.Entity is IAuditInfo &&
                    (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entry in changedEntries)
            {
                var entity = (IAuditInfo)entry.Entity;
                if (entry.State == EntityState.Added && entity.CreatedOn == default)
                {
                    entity.CreatedOn = DateTime.UtcNow;
                }
                else
                {
                    entity.ModifiedOn = DateTime.UtcNow;
                }
            }
        }
    }
}
