using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Domain.Dtoes
{
    public class VisitDto
    {
        public int Id { get; set; }
        public string Caption { get; set; } 
        public DateTime Date { get; set; } 

        public int DoctorId { get; set; }

        public int PatientId { get; set; }

        public decimal Price { get; set; } 
        public int InstallmentCount { get; set; } 
        public decimal? InstallmentPay { get; set; } 
    }
}
