using Clinic.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BillController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Routes.GetLiabilityPatientById)]
        public async Task<ActionResult<int>> GetLiabilityPatientById([FromQuery] int id)
        {
            var result = await _mediator.Send(new GetLiabilityPatientByIdQuery(id));
            return result;
        }

        [HttpGet(Routes.GetLiabilityPatientByIdentity)]
        public async Task<ActionResult<int>> GetLiabilityPatientByIdentity([FromQuery] string id)
        {
            var result = await _mediator.Send(new GetLiabilityPatientByIdentityQuery(id));
            return result;
        }

        [HttpGet(Routes.GetPaymentOfInsuredById)]
        public async Task<ActionResult<decimal>> GetPaymentOfInsuredById([FromQuery] int id)
        {
            var result = await _mediator.Send(new GetPaymentOfInsuredByIdQuery(id));
            return result;
        }

        [HttpGet(Routes.GetPaymentOfInsuredByNumber)]
        public async Task<ActionResult<decimal>> GetPaymentOfInsuredByNumber([FromQuery] string id)
        {
            var result = await _mediator.Send(new GetPaymentOfInsuredByNumberQuery(id));
            return result;
        }
    }
}
