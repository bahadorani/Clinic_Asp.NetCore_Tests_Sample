using Clinic.Domain.Models;

namespace Clinic.DomainTest.Config
{
    internal static class ClinicMoq
    {
        private static User _user;
        private static Visit _visit;
        private static Bill _bill;
        private static Doctor _doctor;
        private static Patient _patient;
        private static Insured _insured;

        public static User GetUser(string name, string family, string tell)
        {
            _user = new User(name,family,tell);
            _user.CenterId = 1;
            return _user;
        }
        public static User GetUser()
        {
            _user = new User("Bahareh", "Bahadorani", "09134568777");
            _user.CenterId = 1;
            return _user;
        }
        public static Patient GetPatient()
        {
            _patient = new Patient("1234567890");
            return _patient;
        }
        public static Patient GetPatient(string number)
        {
            _patient = new Patient(number);
            return _patient;
        }
        public static Bill GetBill()
        {
            _bill = new Bill(120000);
            return _bill;
        }
        public static Bill GetBill(decimal price)
        {
            _bill = new Bill(price);
            return _bill;
        }
        public static Insured GetInssured()
        {
            _insured = new Insured("Asia", "09134568777", "1234567890");
            return _insured;
        }
        public static Insured GetInssured(string title, string tell, string number)
        {
            _insured = new Insured(title, tell, number);
            return _insured;
        }
        //public static Visit GetVisit(string email , string bankAccountNumber )
        //{
        //    DateOnly dateOnly = new DateOnly(2000, 1, 1);
        //    _customer = new Customers("Alz", "Najafi", email, dateOnly, "+989383810430", bankAccountNumber);
        //    return _customer;
        //}
        //public static Customers GetCustomer(string firstName, string lastName,DateTime dateTime, string phoneNumber, string email, string bankAccountNumber)
        //{
        //    DateOnly dateOnly = new DateOnly(2000, 1, 1);
        //    _customer = new Customers(firstName, lastName, email, dateOnly, "+989383810430", bankAccountNumber);
        //    return _customer;
        //}
    }
}
