using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Domain.Dtoes
{
    public class PatientDto
    {
        public int Id { get; set; }
        public string IdentityCart { get; set; }
        public int UserId { get; set; }
        public int? InsuranceId { get; set; }
        public string? Caption { get; set; }
    }
}
