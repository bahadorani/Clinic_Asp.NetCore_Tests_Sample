using Clinic.Domain.Models;
using Clinic.Repository.Interfaces;

namespace Clinic.Persistence.Repositories
{
    public class PatientRepository : Repository<Patient>, IPatientRepository
    {
        public PatientRepository(ProjectContext context) : base(context)
        {
        }
    }
}
