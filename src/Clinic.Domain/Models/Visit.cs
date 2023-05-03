using Clinic.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinic.Domain.Models
{
    public class Visit
    {
        public int Id { get; set; }
        public string Caption { get; set; } = null!;
        public DateTime Date { get;}= DateTime.Now;

        public int DoctorId { get; set; }
        [ForeignKey("DoctorId")]
        public Doctor Doctor { get; set; } = null!;

        public int PatientId { get; set; }
        [ForeignKey("PatientId")]
        public Patient Patient { get; set; } = null!;

        public Money Price { get; set; } = null!;

        public bool IsPayed { get; set; } = false;

        public virtual ICollection<Bill> Bills { get; init; } = new List<Bill>();


    }
}
