using System;
using System.Collections.Generic;

#nullable disable

namespace NETAPI_SEM3.Entities
{
    public partial class AdPackage
    {
        public AdPackage()
        {
            MemberPackageDetails = new HashSet<MemberPackageDetail>();
        }

        public int PackageId { get; set; }
        public string NameAdPackage { get; set; }
        public int? Period { get; set; }
        public decimal? Price { get; set; }
        public string Description { get; set; }
        public int? Amount { get; set; }

        public virtual ICollection<MemberPackageDetail> MemberPackageDetails { get; set; }
    }
}
