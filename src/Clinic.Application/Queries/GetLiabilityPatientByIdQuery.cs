using MediatR;

namespace Clinic.Application.Queries
{
    public class GetLiabilityPatientByIdQuery:IRequest<int>
    {
        public int Id { get; set; }
        public GetLiabilityPatientByIdQuery(int id)
        {
            Id = id;
        }
    }
}
