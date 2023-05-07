using Clinic.Domain.Dtoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.AcceptanceTest
{
    public class ClinicResponse : Response<VisitDto>
    {
        public ClinicResponse(VisitDto successData) : base(successData)
        {
        }
        protected ClinicResponse()
        { }
    }
}
