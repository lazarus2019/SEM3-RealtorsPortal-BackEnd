using System;
using System.Collections.Generic;

#nullable disable

namespace NETAPI_SEM3.Models
{
    public partial class MemberPackageDetail
    {
        public int MPDetailId { get; set; }
        public int MemberId { get; set; }
        public int PackageId { get; set; }
        public DateTime? ExpiryDate { get; set; }

        public virtual Member Member { get; set; }
        public virtual AdPackage Package { get; set; }
    }
}
