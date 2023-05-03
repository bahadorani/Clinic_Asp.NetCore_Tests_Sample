using Clinic.Domain.Models;
using Clinic.Repository.Interfaces;

namespace Clinic.Persistence.Repositories
{
    internal class InuredRepository : Repository<Insured>, IInsuredRepository
    {
        public InuredRepository(ProjectContext context) : base(context)
        {
        }
    }
}
