using Clinic.Domain.Models;
using Clinic.Repository.Interfaces;

namespace Clinic.Persistence.Repositories
{
    public class BillRepository : Repository<Bill>, IBillRepository
    {
        public BillRepository(ProjectContext context) : base(context)
        {
        }
    }
}
