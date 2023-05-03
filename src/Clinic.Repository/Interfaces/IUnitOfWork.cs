using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Repository.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBillRepository BillRepository { get; }
        ICenterRepository CenterRepository { get; }
        IDoctorRepository DoctorRepository { get; }
        IExpertRepository ExpertRepository { get; }
        IInsuranceRepository InsuranceRepository { get; }
        IInsuredRepository InuredRepository { get; }
        IPatientRepository PatientRepository { get; }
        IUserRepository UserRepository { get; }
        IVisitRepository VisitRepository { get; }
        Task<int> Save();
    }
}
