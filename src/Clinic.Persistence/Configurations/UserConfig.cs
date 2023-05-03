using Clinic.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clinic.Persistence.Configurations
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(a => a.Id);

            builder.OwnsOne(pi => pi.Name, builder =>
            {
                builder.Property(p => p.Value)
                .HasColumnName("Name")
                .HasColumnType("varchar(200)")
                .HasMaxLength(200)
                .IsRequired();
            });

            builder.OwnsOne(pi => pi.Family, builder =>
            {
                builder.Property(p => p.Value)
                .HasColumnName("Family")
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

            builder.HasOne(b => b.Center)
                .WithMany(a => a.Users)
                .HasForeignKey(b => b.CenterId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
