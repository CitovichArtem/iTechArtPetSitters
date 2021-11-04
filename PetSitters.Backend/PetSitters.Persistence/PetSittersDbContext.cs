using Microsoft.EntityFrameworkCore;
using PetSitters.Application.Interfaces;
using PetSitters.Domain;
using PetSitters.Persistence.EntityTypeConfigurations;

namespace PetSitters.Persistence
{
    public class ServicesDbContext : DbContext, IServicesDbContext

    {
        public DbSet<Service> Services { get; set; }
        public ServicesDbContext(DbContextOptions<ServicesDbContext> options)
            : base(options) { }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ServiceConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
