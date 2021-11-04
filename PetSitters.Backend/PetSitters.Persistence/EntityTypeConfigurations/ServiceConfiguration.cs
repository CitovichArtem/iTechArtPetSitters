using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetSitters.Domain;

namespace PetSitters.Persistence.EntityTypeConfigurations
{
    public class ServiceConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.HasKey(service => service.Id);
            builder.HasIndex(service => service.Id).IsUnique();
            builder.Property(service => service.Name).HasMaxLength(255);

        }
    }
}
