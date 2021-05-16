using System;
using System.Collections.Generic;

#nullable disable

namespace NETAPI_SEM3.Entities
{
    public partial class MemberPackageDetail
    {
        public int MemberId { get; set; }
        public int PackageId { get; set; }
        public int? PaymentId { get; set; }
        public DateTime? ExpiryDate { get; set; }

        public virtual Member Member { get; set; }
        public virtual AdPackage Package { get; set; }
        public virtual Payment Payment { get; set; }
    }
}
