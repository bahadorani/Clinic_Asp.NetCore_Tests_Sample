using Clinic.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clinic.Persistence.Configurations
{
    public class VisitConfig : IEntityTypeConfiguration<Visit>
    {
        public void Configure(EntityTypeBuilder<Visit> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(c => c.Caption)
              .IsRequired()
              .HasMaxLength(500);

            builder.OwnsOne(pi => pi.Price, builder =>
            {
                builder.Property(p => p.Value)
                .HasColumnName("Price")
                .HasColumnType("decimal")
                .IsRequired();
            });

            builder.OwnsOne(pi => pi.InstallmentPay, builder =>
            {
                builder.Property(p => p.Value)
                .HasColumnName("InstallmentPay")
                .HasColumnType("decimal");
            });

            builder.HasOne(b => b.Doctor)
                .WithMany(a => a.Visits)
                .HasForeignKey(b => b.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(b => b.Patient)
               .WithMany(a => a.Visits)
               .HasForeignKey(b => b.PatientId)
               .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
