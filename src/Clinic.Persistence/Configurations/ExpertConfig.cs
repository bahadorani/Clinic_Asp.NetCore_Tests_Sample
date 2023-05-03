using Clinic.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clinic.Persistence.Configurations
{
    public class ExpertConfig : IEntityTypeConfiguration<Expert>
    {
        public void Configure(EntityTypeBuilder<Expert> builder)
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
        }
    }
}
