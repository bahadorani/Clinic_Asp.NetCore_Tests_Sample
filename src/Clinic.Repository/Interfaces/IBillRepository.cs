using Clinic.Domain.Dtoes;
using Clinic.Domain.Models;

namespace Clinic.Repository.Interfaces
{
    public interface IBillRepository: IRepository<Bill>
    {
        int GetLiabilityPatientById(int id);
        int GetLiabilityPatientByIdentity(string identityCart);
        decimal GetPaymentOfInsuredById(int id);
        decimal GetPaymentOfInsuredByNumber(string number);

    }
}
