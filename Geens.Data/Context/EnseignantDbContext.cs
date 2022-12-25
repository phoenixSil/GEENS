using Geens.Domain.Modeles;
using Microsoft.EntityFrameworkCore;

namespace Geens.Data.Context
{
    public class EnseignantDbContext: DbContext
    {
        public EnseignantDbContext(DbContextOptions<EnseignantDbContext> options) : base(options)
        {

        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<Enseignant>())
            {
                entry.Entity.DateDerniereModification = DateTime.UtcNow;

                if (entry.State == EntityState.Added)
                {
                    entry.Entity.DateCreation = DateTime.Now;
                    entry.Entity.DateDembauche = DateTime.Now;
                }
                    
            }
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EnseignantDbContext).Assembly);
        }

        public DbSet<Enseignant> Enseignants { get; set; }
        public DbSet<Adresse> Adresses { get; set; }
    }
}
