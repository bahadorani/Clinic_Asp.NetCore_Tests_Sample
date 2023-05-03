using Clinic.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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
        public DbSet<Insurance> Insurances { get; set; }
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
