
using Clinic.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clinic.Persistence.Configurations
{
    public class InsuredConfig : IEntityTypeConfiguration<Insured>
    {
        public void Configure(EntityTypeBuilder<Insured> builder)
        {
            builder.HasKey(a => a.Id);

            builder.OwnsOne(pi => pi.Title, builder =>
            {
                builder.Property(p => p.Value)
                .HasColumnName("Title")
                .HasColumnType("varchar(200)")
                .HasMaxLength(200)
                .IsRequired();
            });

            builder.OwnsOne(pi => pi.Tell, builder =>
            {
                builder.Property(p => p.Value)
                .HasColumnName("Tell")
                .HasColumnType("varchar(20)")
                .HasMaxLength(20)
                .IsRequired();
            });

        }
    }
}
