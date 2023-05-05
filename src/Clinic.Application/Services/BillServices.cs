using Clinic.Application.Services.Interfaces;
using Clinic.Domain.Dtoes;
using Clinic.Persistence;
using Clinic.Repository.Interfaces;

namespace Clinic.Application.Services
{
    public class BillServices : IBillServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public BillServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public  int GetLiabilityPatientById(int patientId)
        {
           return _unitOfWork.BillRepository.GetLiabilityPatientById(patientId);
        }

        public int GetLiabilityPatientByIdentity(string patientIdentityId)
        {
            return _unitOfWork.BillRepository.GetLiabilityPatientByIdentity(patientIdentityId);
        }

        public decimal GetPaymentOfInsuredById(int insuredId)
        {
            return _unitOfWork.BillRepository.GetPaymentOfInsuredById(insuredId);
        }

        public decimal GetPaymentOfInsuredByNumber(string number)
        {
            return _unitOfWork.BillRepository.GetPaymentOfInsuredByNumber(number);
        }
    }
}
