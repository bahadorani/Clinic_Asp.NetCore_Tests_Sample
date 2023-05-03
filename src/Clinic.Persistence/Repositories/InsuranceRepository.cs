
using Clinic.Domain.Models;
using Clinic.Repository.Interfaces;

namespace Clinic.Persistence.Repositories
{
    public class InsuranceRepository : Repository<Insurance>, IInsuranceRepository
    {
        public InsuranceRepository(ProjectContext context) : base(context)
        {
        }
    }
}
