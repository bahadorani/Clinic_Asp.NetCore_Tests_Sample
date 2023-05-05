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
    public class GetLiabilityPatientByIdentityQueryHandler : IRequestHandler<GetLiabilityPatientByIdentityQuery, int>
    {
        private readonly IBillServices _service;
        public GetLiabilityPatientByIdentityQueryHandler(IBillServices service)
        {
            _service = service;
        }
        public async Task<int> Handle(GetLiabilityPatientByIdentityQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return _service.GetLiabilityPatientByIdentity(request.Identity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}