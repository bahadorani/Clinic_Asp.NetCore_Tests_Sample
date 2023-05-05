using Clinic.Domain.Dtoes;
using Clinic.Domain.Models;
using Clinic.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Persistence.Repositories
{
    public class BillRepository : Repository<Bill>, IBillRepository
    {
        private readonly ProjectContext _context;
        public BillRepository(ProjectContext context) : base(context)
        {
            _context = context;
        }

        public int GetLiabilityPatientById(int id)
        {
            //var query = _context.Bills.Include(a => a.Visit)
            //                     .ThenInclude(a => a.Patient)
            //                     .ThenInclude(a => a.insurance)
            //                     .Where(a => a.Visit.PatientId.Equals(id))
            //                     .Where(a => a.Visit.IsPayed == false)
                                 
            //                     .Select(b=> new BillDto
            //                     {
            //                         VisitId=b.VisitId,
            //                         Payments=b.Payment.Value,
            //                         InstallmentCount=b.Visit.InstallmentCount,
            //                         InstallmentPay=b.Visit.InstallmentPay.Value
            //                     })
            //                     .GroupBy(a => a.VisitId).Select(d=> new BillDto { d.Key.})
            //                     .ToList();


            var entryPoint = (from b in _context.Bills
                              join v in _context.Visits on b.VisitId equals v.Id
                              join p in _context.Patients on v.PatientId equals p.Id
                              join i in _context.Insureds on p.InsuranceId equals i.Id
                              where p.Id == id &&
                                    v.IsPayed == false && 
                                    v.Doctor.ExpertId != null

                              select new
                              {
                                  visitId = v.Id,
                                  payments = b.Payment.Value,
                                  installmentCount = b.Visit.InstallmentCount,
                                  installmentPay = b.Visit.InstallmentPay.Value,
                                  price = b.Visit.Price.Value
                              })
                              .GroupBy(a => new { a.visitId, a.payments, a.price, a.installmentPay })
                              .Select(a => new BillDto
                              {
                                  VisitId = a.Key.visitId,
                                  InstallmentCount = ((a.Key.price) - (a.Sum(q => q.payments))) / (a.Key.installmentPay)
                              }).Sum(a=>a.InstallmentCount);

            return Convert.ToInt32(entryPoint);

        }
        public int GetLiabilityPatientByIdentity(string identityCart)
        {
            var entryPoint = (from b in _context.Bills
                              join v in _context.Visits on b.VisitId equals v.Id
                              join p in _context.Patients on v.PatientId equals p.Id
                              join i in _context.Insureds on p.InsuranceId equals i.Id
                              where p.IdentityCart.Value == identityCart && 
                                    v.IsPayed == false && v.Doctor.ExpertId!=null

                              select new
                              {
                                  visitId = v.Id,
                                  payments = b.Payment.Value,
                                  installmentCount = b.Visit.InstallmentCount,
                                  installmentPay = b.Visit.InstallmentPay.Value,
                                  price = b.Visit.Price.Value
                              })
                              .GroupBy(a => new { a.visitId, a.payments, a.price, a.installmentPay })
                              .Select(a => new BillDto
                              {
                                  VisitId = a.Key.visitId,
                                  InstallmentCount = ((a.Key.price) - (a.Sum(q => q.payments))) / (a.Key.installmentPay)
                              }).Sum(a => a.InstallmentCount);

            return Convert.ToInt32(entryPoint);

        }
        public decimal GetPaymentOfInsuredById(int id)
        {
            var entryPoint = (from b in _context.Bills
                              join v in _context.Visits on b.VisitId equals v.Id
                              join p in _context.Patients on v.PatientId equals p.Id
                              join i in _context.Insureds on p.InsuranceId equals i.Id
                              where i.Id == id && p.InsuranceId!=null

                              select new
                              {
                                  visitId = v.Id,
                                  payments = b.Payment.Value,
                              })
                              .Sum(a => a.payments);
                              
            return entryPoint;

        }
        public decimal GetPaymentOfInsuredByNumber(string  number)
        {
            var entryPoint = (from b in _context.Bills
                              join v in _context.Visits on b.VisitId equals v.Id
                              join p in _context.Patients on v.PatientId equals p.Id
                              join i in _context.Insureds on p.InsuranceId equals i.Id
                              where i.IdentityNumber.Value == number && p.InsuranceId != null

                              select new
                              {
                                  visitId = v.Id,
                                  payments = b.Payment.Value,
                              })
                              .Sum(a => a.payments);

            return entryPoint;

        }

    }
}