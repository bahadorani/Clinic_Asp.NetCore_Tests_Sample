using System.ComponentModel.DataAnnotations.Schema;

namespace Clinic.Domain.Models
{
    public  class Insurance
    {
        public int Id { get; set; }
        public string Number { get; set; } = null!;
        public DateTime ExpiredDate { get;} = DateTime.Now.AddDays(365);
        public int InsuredId { get; set; }
        [ForeignKey("InsuredId")]
        public Insured Insured { get; set; } = null!;

        public virtual ICollection<Patient> Patients { get; init; } = new List<Patient>();
    }
}
