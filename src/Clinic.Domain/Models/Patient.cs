using Clinic.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinic.Domain.Models
{
    public class Patient
    {
        protected Patient()
        {
        }
        public Patient(string identityNumber)
        {
            Number validateNumber = new Number(identityNumber);
            IdentityCart = validateNumber;
        }

        public int Id { get; set; }
        public Number IdentityCart { get; }//با فرض اینکه شماره هر بیمار یک شماره منحصر به فرد ده رقمی است
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; init; } = null!;

        public int? InsuranceId { get; set; }
        [ForeignKey("InsuranceId")]
        public Insurance? insurance { get; init; } 

        public string? Caption { get; set; }

        public virtual ICollection<Visit> Visits { get; init; } = new List<Visit>();
    }
}
