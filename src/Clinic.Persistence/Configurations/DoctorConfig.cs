using Clinic.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clinic.Persistence.Configurations
{
    public class DoctorConfig : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.HasKey(a => a.Id);

            builder.HasOne(b => b.User)
                .WithMany(a => a.Doctors)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(b => b.Expert)
                .WithMany(a => a.Doctors)
                .HasForeignKey(b => b.ExpertId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
