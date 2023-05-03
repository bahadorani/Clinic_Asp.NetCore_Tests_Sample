using System.ComponentModel.DataAnnotations.Schema;

namespace Clinic.Domain.Models
{
    public class Patient
    {
        protected Patient()
        {
        }
        
        public int Id { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; init; } = null!;

        public int InsuranceId { get; set; }
        [ForeignKey("InsuranceId")]
        public Insurance insurance { get; init; } = null!;

        public string Caption { get; set; }
    }
}
