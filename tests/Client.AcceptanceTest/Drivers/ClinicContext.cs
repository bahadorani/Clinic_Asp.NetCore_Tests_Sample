using Clinic.Domain.Dtoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.AcceptanceTest.Drivers
{
    public class ClinicContext
    {
        public BillDto BillContext { get; set; }
        public VisitDto VisitContext { get; set; }
        public DoctorDto DoctorContext { get; set; }
        public InsuranceDto InsuranceContext { get; set; }
        public PatientDto PatientContext { get; set; }
        public CenterDto CenterContext { get; set; }
        public UserDto UserContext { get; set; }
        public ExpertDto ExpertContext { get; set; }
    }
}
