using Clinic.Domain.Dtoes;

namespace Clinic.Application.Services.Interfaces
{
    public interface IBillServices
    {
        int GetLiabilityPatientById(int patientId);
        int GetLiabilityPatientByIdentity(string patientIdentityId);

        decimal GetPaymentOfInsuredById(int insuredId);
        decimal GetPaymentOfInsuredByNumber(string number);
    }                     
}