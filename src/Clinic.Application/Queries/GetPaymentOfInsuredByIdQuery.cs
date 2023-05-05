using MediatR;

namespace Clinic.Application.Queries
{
    public class GetPaymentOfInsuredByIdQuery : IRequest<decimal>
    {
        public int Id { get; set; }
        public GetPaymentOfInsuredByIdQuery(int id)
        {
            Id = id;
        }
    }
}
