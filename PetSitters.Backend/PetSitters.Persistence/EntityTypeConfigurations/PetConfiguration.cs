using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetSitters.Domain;

namespace PetSitters.Persistence.EntityTypeConfigurations
{
    public class PetConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.HasKey(pet => pet.Id);
            builder.HasIndex(pet => pet.Id).IsUnique();
            builder.Property(pet => pet.Name).HasMaxLength(255);

        }
    }
}