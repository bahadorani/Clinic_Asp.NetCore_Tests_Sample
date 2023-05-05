using Clinic.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinic.Domain.Models
{
    public class Visit
    {
        protected Visit()
        {
        }
        public Visit(decimal price, decimal installmentPay)
        {
            Money  validatePrice = new Money(price);
            Price = validatePrice;

            validatePrice = new Money(installmentPay);
            InstallmentPay = validatePrice;

        }
        public int Id { get; set; }
        public string Caption { get; set; } = null!;
        public DateTime Date { get;}= DateTime.Now;

        public int DoctorId { get; set; }
        [ForeignKey("DoctorId")]
        public Doctor Doctor { get; set; } = null!;

        public int PatientId { get; set; }
        [ForeignKey("PatientId")]
        public Patient Patient { get; set; } = null!;

        public Money Price { get;} = null!;

        public bool IsPayed { get; set; } = false;//تسویه کامل شده است یا خیر؟
        public int InstallmentCount { get; set; } = 0;//تعداد اقساط
        public Money? InstallmentPay { get;} = null; //مبلغ قسط

        public virtual ICollection<Bill> Bills { get; init; } = new List<Bill>();


    }
}
