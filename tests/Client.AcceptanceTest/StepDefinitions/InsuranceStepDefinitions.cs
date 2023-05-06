using Client.AcceptanceTest.Drivers;
using System;
using TechTalk.SpecFlow;

namespace Client.AcceptanceTest.StepDefinitions
{
    [Binding]
    public class InsuranceStepDefinitions
    {
        private readonly ClinicDriver _driver;

        public InsuranceStepDefinitions(ClinicDriver driver)
        {
            _driver = driver;
        }
        [Given(@"the patients with below data")]
        public void GivenThePatientsWithBelowData(Table table)
        {
            _driver.SetPatientInfo(table);
        }

        [Given(@"a insurance company with below data")]
        public void GivenAInsuranceCompanyWithBelowData(Table table)
        {
            _driver.SetInsuranceInfo(table);
        }

        [When(@"This insurance company pays for the treatment of patients under its coverage according to the following information")]
        public void WhenThisInsuranceCompanyPaysForTheTreatmentOfPatientsUnderItsCoverageAccordingToTheFollowingInformation(Table table)
        {
            _driver.SetBillInfo(table);
        }

        [Then(@"the result of The total amount paid by company ""([^""]*)"" for covered patients is ""([^""]*)"" Tomans\.")]
        public async Task ThenTheResultOfTheTotalAmountPaidByCompanyForCoveredPatientsIsTomans_Async(string p0, string p1)
        {
            int respond = await _driver.CountInsurancePayments(int.Parse(p0));
            Assert.Equal(p1, respond.ToString());
        }
    }
}
