using Clinic.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinic.Domain.Models
{
    public class Bill
    {
        protected Bill()
        {
        }
        public Bill(decimal price)
        {
            Money validatePrice = new Money(price);
            Payment = validatePrice;
        }
        public int Id { get; set; }
        public int VisitId { get; set; }
        [ForeignKey("VisitId")]
        public Visit Visit { get; set; } = null!;

        public DateTime Date { get;} = DateTime.Now;

        public Money Payment { get; } = null!;
    }
}
