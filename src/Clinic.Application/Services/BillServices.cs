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
            try 
            {
                return _unitOfWork.BillRepository.GetLiabilityPatientById(patientId);
            }
            catch(Exception ex) {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public int GetLiabilityPatientByIdentity(string patientIdentityId)
        {
            try
            {
                return _unitOfWork.BillRepository.GetLiabilityPatientByIdentity(patientIdentityId);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public decimal GetPaymentOfInsuredById(int insuredId)
        {
            try
            {
                return _unitOfWork.BillRepository.GetPaymentOfInsuredById(insuredId);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public decimal GetPaymentOfInsuredByNumber(string number)
        {
            try
            {
                return _unitOfWork.BillRepository.GetPaymentOfInsuredByNumber(number);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
    }
}
