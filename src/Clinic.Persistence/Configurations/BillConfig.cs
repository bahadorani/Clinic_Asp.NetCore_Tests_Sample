using Clinic.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clinic.Persistence.Configurations
{
    public class BillConfig : IEntityTypeConfiguration<Bill>
    {
        public void Configure(EntityTypeBuilder<Bill> builder)
        {
            builder.HasKey(a => a.Id);

            builder.OwnsOne(pi => pi.Payment, builder =>
            {
                builder.Property(p => p.Value)
                .HasColumnName("Payment")
                .HasColumnType("decimal")
                .IsRequired();
            });

            builder.HasOne(b => b.Visit)
                .WithMany(a => a.Bills)
                .HasForeignKey(b => b.VisitId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
