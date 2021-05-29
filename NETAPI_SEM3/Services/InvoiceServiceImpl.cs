using NETAPI_SEM3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETAPI_SEM3.Services
{
    public class InvoiceServiceImpl : InvoiceService
    {
        private readonly DatabaseContext _db;

        public InvoiceServiceImpl(DatabaseContext db)
        {
            this._db = db;
        }

        public bool CheckPackage(int memberId)
        {
            try
            {

                var packageDetail = _db.MemberPackageDetails.SingleOrDefault(pd => pd.MemberId == memberId);
                _db.Remove(packageDetail);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }

        public Invoice CreateInvoice(Invoice invoice)
        {
            try
            {
                if (invoice != null)
                {
                    _db.Invoices.Add(invoice);
                    _db.SaveChanges();
                }
                return invoice;
            }
            catch
            {
                return null;
            }
        }
    }
}
