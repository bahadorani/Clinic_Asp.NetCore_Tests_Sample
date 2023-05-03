using System.ComponentModel.DataAnnotations.Schema;

namespace Clinic.Domain.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; init; } = null!;

        public int? ExpertId { get; set; }
        [ForeignKey("ExpertId")]
        public Expert? Expert { get; init; }

    }
}
