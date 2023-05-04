using Clinic.Domain.Dtoes;

namespace Clinic.Application.Services.Interfaces
{
    public interface IBillServices
    {
        Task<BillDto> GetLiabilityPatientById(int patientId);
        Task<BillDto> GetLiabilityPatientByIdentity(int patientIdentityId);

        Task<BillDto> GetLiabilityPatientCountById(int patientId);
        Task<BillDto> GetLiabilityPatientCountByIdentity(int patientIdentityId);

        Task<BillDto> GetPaymentOfInsuredById(int insuredId);
        Task<BillDto> GetPaymentOfInsuredByNumber(string number);
    }                     
}