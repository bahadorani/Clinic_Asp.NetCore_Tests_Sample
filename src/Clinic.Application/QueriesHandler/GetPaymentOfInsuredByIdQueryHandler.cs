using Clinic.Application.Queries;
using Clinic.Application.Services.Interfaces;
using MediatR;


namespace Clinic.Application.QueriesHandler
{
    public class GetPaymentOfInsuredByIdQueryHandler : IRequestHandler<GetPaymentOfInsuredByIdQuery, decimal>
    {
        private readonly IBillServices _service;
        public GetPaymentOfInsuredByIdQueryHandler(IBillServices service)
        {
            _service = service;
        }
        public async Task<decimal> Handle(GetPaymentOfInsuredByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return _service.GetPaymentOfInsuredById(request.Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
