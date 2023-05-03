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

        }
    }
}
