using Clinic.Domain.ValueObjects;

namespace Clinic.Domain.Models
{
    public class Insured
    {
        protected Insured()
        {
        }
        public Insured(string title, string tell)
        {
            Name validateName = new Name(title);
            Title = validateName;

            Mobile mobile = new Mobile(tell);
            Tell = mobile;
        }
        public int Id { get; set; }
        public Name Title { get;} = null!;
        public string? Address { get; set; }
        public Mobile Tell { get; } = null!;

        public virtual ICollection<Insurance> Insurances { get; init; } = new List<Insurance>();
    }
}
