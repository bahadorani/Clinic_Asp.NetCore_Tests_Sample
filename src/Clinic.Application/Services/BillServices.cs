using Clinic.Application.Services.Interfaces;
using Clinic.Domain.Dtoes;
using Clinic.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.Services
{
    public class BillServices : IBillServices
    {
        private readonly ProjectContext _context;

        public BillServices(ProjectContext context)
        {
            _context = context;
        }

        public Task<BillDto> GetLiabilityPatientById(int patientId)
        {
            throw new NotImplementedException();
        }

        public Task<BillDto> GetLiabilityPatientByIdentity(int patientIdentityId)
        {
            throw new NotImplementedException();
        }

        public Task<BillDto> GetLiabilityPatientCountById(int patientId)
        {
            throw new NotImplementedException();
        }

        public Task<BillDto> GetLiabilityPatientCountByIdentity(int patientIdentityId)
        {
            throw new NotImplementedException();
        }

        public Task<BillDto> GetPaymentOfInsuredById(int insuredId)
        {
            throw new NotImplementedException();
        }

        public Task<BillDto> GetPaymentOfInsuredByNumber(string number)
        {
            throw new NotImplementedException();
        }

        private async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
