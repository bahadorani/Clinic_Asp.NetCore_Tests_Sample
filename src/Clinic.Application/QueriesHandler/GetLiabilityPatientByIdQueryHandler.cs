using Clinic.Application.Queries;
using Clinic.Application.Services.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.QueriesHandler
{
    public class GetLiabilityPatientByIdQueryHandler : IRequestHandler<GetLiabilityPatientByIdQuery, int>
    {
        private readonly IBillServices _service;
        public GetLiabilityPatientByIdQueryHandler(IBillServices service)
        {
            _service = service;
        }
        public async Task<int> Handle(GetLiabilityPatientByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return _service.GetLiabilityPatientById(request.Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
