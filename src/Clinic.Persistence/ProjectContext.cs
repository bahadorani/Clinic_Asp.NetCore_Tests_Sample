using Clinic.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Clinic.Persistence
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Bill> Bills { get; set; }
        public DbSet<Center> Centers { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Expert> Experts { get; set; }
        public DbSet<Insured> Insureds { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Visit> Visits { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
