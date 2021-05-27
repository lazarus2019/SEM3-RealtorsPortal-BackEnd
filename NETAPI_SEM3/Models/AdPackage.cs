using System;
using System.Collections.Generic;

#nullable disable

namespace NETAPI_SEM3.Models
{
    public partial class AdPackage
    {
        public AdPackage()
        {
            Invoices = new HashSet<Invoice>();
            MemberPackageDetails = new HashSet<MemberPackageDetail>();
        }

        public int PackageId { get; set; }
        public string NameAdPackage { get; set; }
        public int? Period { get; set; }
        public decimal? Price { get; set; }
        public string Description { get; set; }
        public bool? StatusBuy { get; set; }
        public int? PostNumber { get; set; }
        public bool? IsDelete { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<MemberPackageDetail> MemberPackageDetails { get; set; }
    }
}
