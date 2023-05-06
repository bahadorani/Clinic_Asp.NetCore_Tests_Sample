using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Domain.Dtoes
{
    public class InsuranceDto
    {
        public int Id { get; set; }
        public string IdentityNumber { get; set; }
        public string Title { get; set; } 
        public string? Address { get; set; }
        public string Tell { get; set; } 
    }
}
