using MediatR;

namespace Clinic.Application.Queries
{
    public class GetPaymentOfInsuredByNumberQuery: IRequest<decimal>
    {
        public string Identity { get; set; }
        public GetPaymentOfInsuredByNumberQuery(string id)
        {
            Identity = id;
        }
    }
}
