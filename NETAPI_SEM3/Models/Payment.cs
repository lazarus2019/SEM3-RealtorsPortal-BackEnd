using System;
using System.Collections.Generic;

#nullable disable

namespace NETAPI_SEM3.Models
{
    public partial class Payment
    {
        public Payment()
        {
            Invoices = new HashSet<Invoice>();
            MemberPackageDetails = new HashSet<MemberPackageDetail>();
        }

        public int PaymentId { get; set; }
        public string PaymentMethod { get; set; }
        public string TotalPrice { get; set; }
        public string PaypalCard { get; set; }
        public int? MemberId { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<MemberPackageDetail> MemberPackageDetails { get; set; }
    }
}
