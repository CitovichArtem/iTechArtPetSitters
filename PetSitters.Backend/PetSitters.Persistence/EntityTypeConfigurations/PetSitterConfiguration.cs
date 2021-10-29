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
    public class PetSitterConfiguration : IEntityTypeConfiguration<PetSitter>
    {
        public void Configure(EntityTypeBuilder<PetSitter> builder)
        {
            builder.HasKey(petsitter => petsitter.Id);
            builder.HasIndex(petsitter => petsitter.Id).IsUnique();
            builder.Property(petsitter => petsitter.Name).HasMaxLength(255);

        }
    }
}
