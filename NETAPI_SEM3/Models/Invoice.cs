using System;
using System.Collections.Generic;

#nullable disable

namespace NETAPI_SEM3.Models
{
    public partial class Invoice
    {
        public int InvoiceId { get; set; }
        public string Name { get; set; }
        public int PackageId { get; set; }
        public DateTime Created { get; set; }
        public decimal Total { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentCard { get; set; }
        public string PaymentCode { get; set; }
        public int MemberId { get; set; }

        public virtual Member Member { get; set; }
        public virtual AdPackage Package { get; set; }
    }
}
