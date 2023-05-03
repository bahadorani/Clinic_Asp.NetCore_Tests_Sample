using Clinic.Domain.ValueObjects;

namespace Clinic.Domain.Models
{
    public class Expert
    {
        protected Expert()
        {
        }
        public Expert(string name)
        {
            Name validateName = new Name(name);
            Title = validateName;
        }
        public int Id { get; set; }
        public Name Title { get; } = null!;

        public virtual ICollection<Doctor> Doctors { get; init; } = new List<Doctor>();
    }
}
