using Clinic.Domain.ValueObjects;

namespace Clinic.Domain.Models
{
    public class Insured
    {
        protected Insured()
        {
        }
        public Insured(string title, string tell, string identityNumber)
        {
            Name validateName = new Name(title);
            Title = validateName;

            Mobile mobile = new Mobile(tell);
            Tell = mobile;

            Number number = new Number(identityNumber);
            IdentityNumber = number;
        }
        public int Id { get; set; }
        public Number IdentityNumber { get;}//با فرض اینکه شماره هر بیمه گر یک شماره منحصر به فرد ده رقمی است
        public Name Title { get;} = null!;
        public string? Address { get; set; }
        public Mobile Tell { get; } = null!;

        public virtual ICollection<Insurance> Insurances { get; init; } = new List<Insurance>();
    }
}
