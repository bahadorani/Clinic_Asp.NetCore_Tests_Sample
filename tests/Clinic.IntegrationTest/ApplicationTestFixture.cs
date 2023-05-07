using Clinic.Domain.Models;
using Clinic.Persistence;
using Clinic.Repository.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Clinic.IntegrationTest
{
    public class ApplicationTestFixture : IDisposable
    {
        public ProjectContext ApplicationDbContext { get; private set; }
        public IMediator Meidator;
        public IUnitOfWork _Unitofwork;

        public ApplicationTestFixture()
        {
            SetServices();
            Center center = new Center("Asia");
            ApplicationDbContext.Centers.Add(center);

            Expert expert = new Expert("Nephrologist");
            ApplicationDbContext.Experts.Add(expert);

            User user1 = new User("Ali", "Zamani", "09132000000");
            user1.CenterId = 1;
            User user2 = new User("Zahra", "Omodi", "09148000000");
            user1.CenterId = 1;
            User user3 = new User("Shadi", "Bahari", "09178000003");
            user1.CenterId = 1;

            ApplicationDbContext.Users.Add(user1);
            ApplicationDbContext.Users.Add(user2);
            ApplicationDbContext.Users.Add(user3);

            ApplicationDbContext.SaveChangesAsync().GetAwaiter().GetResult();

            Insured insured = new Insured("Asia", "09178200336", "1234567890");
            ApplicationDbContext.Insureds.Add(insured);

            ApplicationDbContext.SaveChangesAsync().GetAwaiter().GetResult();

            Patient patient1 = new Patient("1472583690");
            patient1.UserId = 1;
            patient1.InsuranceId = null;

            Patient patient2 = new Patient("9632583147");
            patient2.UserId = 3;
            patient2.InsuranceId = 1;
            patient2.Insured = insured;

            ApplicationDbContext.Patients.Add(patient1);
            ApplicationDbContext.Patients.Add(patient2);
            ApplicationDbContext.SaveChangesAsync().GetAwaiter().GetResult();

            Doctor doctor = new Doctor();
            doctor.UserId = 2;
            doctor.ExpertId = 1;
            ApplicationDbContext.Doctors.Add(doctor);
            ApplicationDbContext.SaveChangesAsync().GetAwaiter().GetResult();

            Visit visit1 = new Visit(150000, 50000);
            visit1.InstallmentCount = 3;
            visit1.DoctorId = 1;
            visit1.PatientId = 1;
            visit1.Caption = "Visit 1";
            visit1.Patient=patient1;
            ApplicationDbContext.Visits.Add(visit1);
            ApplicationDbContext.SaveChangesAsync().GetAwaiter().GetResult();

            Visit visit2 = new Visit(150000, 150000);
            visit2.InstallmentCount = 1;
            visit2.DoctorId = 1;
            visit2.PatientId = 2;
            visit2.Patient=patient2;
            visit2.Caption = "Visit 2";
            ApplicationDbContext.Visits.Add(visit2);
            ApplicationDbContext.SaveChangesAsync().GetAwaiter().GetResult();

            Bill bill1 = new Bill(50000);
            bill1.VisitId = 1;
            bill1.Visit=visit1;
            ApplicationDbContext.Bills.Add(bill1);
            ApplicationDbContext.SaveChangesAsync().GetAwaiter().GetResult();

            Bill bill2 = new Bill(150000);
            bill1.VisitId = 2;
            bill2.Visit=visit2;
            ApplicationDbContext.Bills.Add(bill2);
            ApplicationDbContext.SaveChangesAsync().GetAwaiter().GetResult();
        }
        private void SetServices()
        {
            var dbName = $"CrudTestDb_{DateTime.Now.ToFileTimeUtc()}";
            var dbContextOptions = new DbContextOptionsBuilder<ProjectContext>()
                .UseInMemoryDatabase(dbName)
                .Options;

            Meidator = new Mock<IMediator>().Object;
            ApplicationDbContext = new ProjectContext(dbContextOptions);
            _Unitofwork = new UnitOfWork(ApplicationDbContext);
        }
        public void Dispose()
        {
            ApplicationDbContext.Dispose();
        }
    }
}
