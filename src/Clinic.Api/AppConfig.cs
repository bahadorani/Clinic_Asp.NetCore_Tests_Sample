namespace Clinic.Api
{
    public struct Routes
    {
        public const string GetLiabilityPatientByIdentity = "/api/getLiabilityPatientByIdentity";
        public const string GetLiabilityPatientById = "/api/getLiabilityPatientByIdQuery";
        public const string GetPaymentOfInsuredById = "/api/getPaymentOfInsuredById";
        public const string GetPaymentOfInsuredByNumber = "/api/getPaymentOfInsuredByNumber";
    }
    public class AppConfig
    {
        public string ApiUrl { get; set; }

        public AppConfig()
        {
            ApiUrl = "http://localhost:5169";
        }
    }
}
