using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETAPI_SEM3.ViewModel
{
    public class InvoiceViewModel
    {
        public int InvoiceId { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public decimal Total { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentCard { get; set; }
        public string PaymentCode { get; set; }
        public int MemberId { get; set; }
        public int PackageId { get; set; } 
        public MemberViewModel Member { get; set; }
        public AdspackageViewModel AdsPackage { get;set; }
    }
}
