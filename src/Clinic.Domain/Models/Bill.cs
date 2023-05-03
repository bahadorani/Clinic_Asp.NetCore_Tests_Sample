using Clinic.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinic.Domain.Models
{
    public class Bill
    {
        public int Id { get; set; }
        public int VisitId { get; set; }
        [ForeignKey("VisitId")]
        public Visit Visit { get; set; } = null!;

        public DateTime Date { get;} = DateTime.Now;

        public Money Payment { get; } = null!;
    }
}
