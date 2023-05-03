using Clinic.Domain.Models;
using Clinic.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Persistence.Repositories
{
    public class DoctorRepository : Repository<Doctor>, IDoctorRepository
    {
        public DoctorRepository(ProjectContext context) : base(context)
        {
        }
    }
}
