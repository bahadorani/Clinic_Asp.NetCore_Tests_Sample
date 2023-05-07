using Clinic.Application.Services;
using Clinic.Application.Services.Interfaces;
using Clinic.Persistence;
using Clinic.Repository.Interfaces;
using MediatR;
namespace Clinic.IntegrationTest
{
    public class ClinicServiceTest : IClassFixture<ApplicationTestFixture>
    {
        private readonly IBillServices _manager;
        private readonly IUnitOfWork _unit;
        private readonly IMediator _mediator;
        private readonly ProjectContext _dbContext;

        public ClinicServiceTest(ApplicationTestFixture fixture)
        {
            _dbContext = fixture.ApplicationDbContext;
            _mediator = fixture.Meidator;
            _unit = fixture._Unitofwork;
            _manager = new BillServices(_unit);
        }

        [Theory]
        [InlineData(1, 0)]
        [InlineData(2, 2)]
        public void should_get_liability_patient_by_id(int id, int count)
        {
            var result = _manager.GetLiabilityPatientById(id);

            Assert.NotNull(result);
            Assert.Equal(count, result);
        }
        [Theory]
        [InlineData(1, 150000)]
        public void should_get_payment_of_insured_by_id(int id, decimal payment)
        {
            var result = _manager.GetPaymentOfInsuredById(id);

            Assert.NotNull(result);
            Assert.Equal(payment, result);
        }
    }

}




