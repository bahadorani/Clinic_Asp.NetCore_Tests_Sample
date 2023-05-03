using Clinic.Domain.Models;
using Clinic.Repository.Interfaces;

namespace Clinic.Persistence.Repositories
{
    public class CenterRepository : Repository<Center>, ICenterRepository
    {
        public CenterRepository(ProjectContext context) : base(context)
        {
        }
    }
}
