using Clinic.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clinic.Persistence.Configurations
{
    public class PatientConfig : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasKey(a => a.Id);

            builder.HasOne(b => b.User)
                .WithMany(a => a.Patients)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(b => b.insurance)
                .WithMany(a => a.Patients)
                .HasForeignKey(b => b.InsuranceId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.OwnsOne(pi => pi.IdentityCart, builder =>
            {
                builder.Property(p => p.Value)
                .HasColumnName("IdentityCart")
                .HasColumnType("varchar(12)")
                .HasMaxLength(12)
                .IsRequired();

                builder.HasIndex(e => new { e.Value }).IsUnique();
            });
            

        }
    }
}
