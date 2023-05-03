
using Clinic.Domain.Models;
using Clinic.Repository.Interfaces;

namespace Clinic.Persistence.Repositories
{
    internal class ExpertRepository : Repository<Expert>, IExpertRepository
    {
        public ExpertRepository(ProjectContext context) : base(context)
        {
        }
    }
}
