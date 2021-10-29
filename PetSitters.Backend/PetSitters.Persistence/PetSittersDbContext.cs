using Microsoft.EntityFrameworkCore;
using PetSitters.Application.Interfaces;
using PetSitters.Domain;
using PetSitters.Persistence.EntityTypeConfigurations;

namespace PetSitters.Persistence
{
    public class PetSittersDbContext : DbContext, IPetSittersDbContext

    {
        public DbSet<PetSitter> PetSitters { get; set; }
        public PetSittersDbContext(DbContextOptions<PetSittersDbContext> options)
            : base(options) { }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new PetSitterConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
