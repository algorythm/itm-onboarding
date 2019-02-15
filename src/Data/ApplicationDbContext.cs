using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using todoProject.Data.EfConfigurations;
using todoProject.Data.Models;

namespace todoProject.Data 
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Todo> Todos { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.ApplyConfiguration(new TodoConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            var addedEntities = ChangeTracker.Entries().Where(e => e.State == EntityState.Added);

            foreach(var entry in addedEntities)
            {
                if (entry.Entity is IAuditable)
                {
                    var entity = entry.Entity as IAuditable;
                    entity.DateCreated = DateTime.Now;
                }
            }

            var editedEntities = ChangeTracker.Entries().Where(e => e.State == EntityState.Modified);

            foreach (var entry in editedEntities)
            {
                if (entry.Entity is IAuditable)
                {
                    var entity = entry.Entity as IAuditable;
                    entity.DateModified = DateTime.Now;
                }
            }

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}
