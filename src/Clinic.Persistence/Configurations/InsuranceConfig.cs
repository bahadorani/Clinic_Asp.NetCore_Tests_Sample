using Clinic.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Persistence.Configurations
{
    public class InsuranceConfig : IEntityTypeConfiguration<Insurance>
    {
        public void Configure(EntityTypeBuilder<Insurance> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(c => c.Number)
             .IsRequired()
             .HasMaxLength(50);

            builder.HasOne(b => b.Insured)
                .WithMany(a => a.Insurances)
                .HasForeignKey(b => b.InsuredId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
