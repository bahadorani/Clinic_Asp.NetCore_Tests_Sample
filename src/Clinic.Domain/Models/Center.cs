using Clinic.Domain.ValueObjects;

namespace Clinic.Domain.Models
{
    public class Center
    {
        protected Center()
        {
        }
        public Center(string name)
        {
            Name validateName = new Name(name);
            Title = validateName;
        }
        public int Id { get; set; }
        public Name Title { get; } = null!;
        public string Address { get; set; }

        public virtual ICollection<User> Users { get; init; } = new List<User>();
    }
}
