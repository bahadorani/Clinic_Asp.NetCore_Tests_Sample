using Clinic.Application.Queries;
using Clinic.Application.Services.Interfaces;
using MediatR;

namespace Clinic.Application.QueriesHandler
{
    public class GetPaymentOfInsuredByNumberQueryHandler : IRequestHandler<GetPaymentOfInsuredByNumberQuery, decimal>
    {
        private readonly IBillServices _service;
        public GetPaymentOfInsuredByNumberQueryHandler(IBillServices service)
        {
            _service = service;
        }
        public async Task<decimal> Handle(GetPaymentOfInsuredByNumberQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return _service.GetPaymentOfInsuredByNumber(request.Identity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
