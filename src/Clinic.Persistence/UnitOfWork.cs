using Clinic.Persistence.Repositories;
using Clinic.Repository.Interfaces;

namespace Clinic.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProjectContext _context;

        public UnitOfWork(ProjectContext context)
        {
            _context = context;
            BillRepository = new BillRepository(_context);
            CenterRepository = new CenterRepository(_context);
            DoctorRepository = new DoctorRepository(_context);
            ExpertRepository = new ExpertRepository(_context);
            InsuranceRepository = new InsuranceRepository(_context);
            InuredRepository = new InuredRepository(_context);
            PatientRepository = new PatientRepository(_context);
            UserRepository = new UserRepository(_context);
            VisitRepository = new VisitRepository(_context);
        }

        public IBillRepository BillRepository { get; set; }
        public ICenterRepository CenterRepository { get; set; }
        public IDoctorRepository DoctorRepository { get; set; }
        public IExpertRepository ExpertRepository { get; set; }
        public IInsuranceRepository InsuranceRepository { get; set;}
        public IInsuredRepository InuredRepository { get; set; }
        public IPatientRepository PatientRepository { get; set; }
        public IUserRepository UserRepository { get; set; }
        public IVisitRepository VisitRepository { get; set; }
        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
