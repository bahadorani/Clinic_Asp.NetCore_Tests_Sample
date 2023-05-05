using MediatR;

namespace Clinic.Application.Queries
{
    public class GetLiabilityPatientByIdentityQuery:IRequest<int>
    {
        public string Identity { get; set; }
        public GetLiabilityPatientByIdentityQuery(string id)
        {
            Identity = id;
        }
    }
}
