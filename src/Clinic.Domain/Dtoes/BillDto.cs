using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Domain.Dtoes
{
    public class BillDto
    {
        public int PatientId { get; set; }
        public int VisitId { get; set; }
        public decimal Payments { get; set; }
        public decimal InstallmentCount { get; set; } 
        public decimal InstallmentPay { get; set; } 

    }
}