using Client.AcceptanceTest.Drivers;
using System;
using TechTalk.SpecFlow;

namespace Client.AcceptanceTest.StepDefinitions
{
    [Binding]
    public class PatientStepDefinitions
    {
        private readonly ClinicDriver _driver;

        public PatientStepDefinitions(ClinicDriver driver)
        {
            _driver = driver;
        }
        [Given(@"clinic info with below data")]
        public void GivenClinicInfoWithBelowData(Table table)
        {
            _driver.SetClinicInfo(table);
        }

        [Given(@"Users infos with below data")]
        public void GivenUsersInfosWithBelowData(Table table)
        {
            _driver.SetUserInfo(table);
        }

        [Given(@"Experts of doctors with bellow data")]
        public void GivenExpertsOfDoctorsWithBellowData(Table table)
        {
            _driver.SetExpertInfo(table);
        }

        [Given(@"Insurance info with below data")]
        public void GivenInsuranceInfoWithBelowData(Table table)
        {
            _driver.SetInsuranceInfo(table);
        }

        [When(@"a patient that is not covered by health insurance with the below data goes to the clinic for treatment")]
        public void WhenAPatientThatIsNotCoveredByHealthInsuranceWithTheBelowDataGoesToTheClinicForTreatment(Table table)
        {
            _driver.SetPatientInfo(table);
        }

        [When(@"a doctor with the following profile is visiting the patients\.")]
        public void WhenADoctorWithTheFollowingProfileIsVisitingThePatients_(Table table)
        {
            _driver.SetDoctorInfo(table);
        }

        [When(@"the patient and the doctor have an appointment together and the patient will pay the treatment fee in installments with the below data")]
        public void WhenThePatientAndTheDoctorHaveAnAppointmentTogetherAndThePatientWillPayTheTreatmentFeeInInstallmentsWithTheBelowData(Table table)
        {
            _driver.SetVisitInfo(table);
        }

        [When(@"the patient pay money of treatment according to visit info in bellow data")]
        public void WhenThePatientPayMoneyOfTreatmentAccordingToVisitInfoInBellowData(Table table)
        {
            _driver.SetBillInfo(table);
        }

        [Then(@"the result of installment that the patient ""([^""]*)"" has not paid is ""([^""]*)"" installment\.")]
        public async Task ThenTheResultOfInstallmentThatThePatientHasNotPaidIsInstallment_Async(string p0, string p1)
        {
            int respond = await _driver.CountInstallmentWithPatientId(int.Parse(p0));
            Assert.Equal(p1, respond.ToString());
        }
    }
}
