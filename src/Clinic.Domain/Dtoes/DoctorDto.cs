using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Domain.Dtoes
{
    public class DoctorDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int? ExpertId { get; set; }

    }
}
