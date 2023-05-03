using Clinic.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clinic.Persistence.Configurations
{
    public class CenterConfig : IEntityTypeConfiguration<Center>
    {
        public void Configure(EntityTypeBuilder<Center> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(c => c.Address)
             .HasMaxLength(500);

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
