using Clinic.Domain.Models;
using Clinic.Repository.Interfaces;

namespace Clinic.Persistence.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ProjectContext context) : base(context)
        {
        }
    }
}
