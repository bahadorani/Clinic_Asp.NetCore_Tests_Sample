using Clinic.Domain.Models;
using Clinic.Repository.Interfaces;

namespace Clinic.Persistence.Repositories
{
    public class VisitRepository : Repository<Visit>, IVisitRepository
    {
        public VisitRepository(ProjectContext context) : base(context)
        {
        }
    }
}
