using Clinic.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinic.Domain.Models
{
    public class User
    {
        protected User()
        {
        }
        public User(string name, string family, string tell)
        {
            Name validateName = new Name(name);
            Name = validateName;

            validateName = new Name(family);
            Family = validateName;

            Mobile mobile = new Mobile(tell);
            Tell = mobile;
        }
        public int Id { get; set; }
        public Name Name { get; } = null!;
        public Name Family { get; } = null!;
        public Mobile Tell { get; } = null!;

        public int CenterId { get; set; }
        [ForeignKey("CenterId")]
        public Center Center { get; init; }=null!;


    }
}
