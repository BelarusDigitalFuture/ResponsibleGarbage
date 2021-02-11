using Microsoft.EntityFrameworkCore;
using Responsiblegarbage.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Responsiblegarbage.Web.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(
           DbContextOptions options) : base(options)
        {


        }


        public DbSet<Product> Products { get; set; }

        public DbSet<Company> Companies { get; set; }

        public DbSet<GarbageType> GarbageTypes { get; set; }

        public DbSet<DumpsterGarbageType> DumpsterGarbageTypes { get; set; }

        public DbSet<Recycler> Recyclers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Dumpster - GarbageType
            modelBuilder.Entity<DumpsterGarbageType>()
             .HasKey(r => new { r.DumpsterId, r.TypeId });

            modelBuilder.Entity<DumpsterGarbageType>()
                  .HasOne(c => c.Dumpster)
                  .WithMany(s => s.Types)
                  .HasForeignKey(r => r.DumpsterId);

            modelBuilder.Entity<DumpsterGarbageType>()
                  .HasOne(c => c.Type)
                  .WithMany(s => s.Dumpsters)
                   .HasForeignKey(r => r.TypeId);

            //postgis
            modelBuilder.HasPostgresExtension("postgis");
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ChangeTracker.DetectChanges();

            //created, updated dates
            var entries = ChangeTracker
                   .Entries()
                   .Where(e => e.Entity is BaseEntity && (
                           e.State == EntityState.Added
                           || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((BaseEntity)entityEntry.Entity).UpdatedAt = DateTime.UtcNow;

                if (entityEntry.State == EntityState.Added)
                {
                    ((BaseEntity)entityEntry.Entity).CreatedAt = DateTime.UtcNow;
                }
            }

            return await base.SaveChangesAsync();
        }

    }
}
