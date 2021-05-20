using System;
using System.Collections.Generic;

#nullable disable

namespace NETAPI_SEM3.Models
{
    public partial class Member
    {
        public Member()
        {
            InvoiceMemberAs = new HashSet<Invoice>();
            InvoiceMemberBs = new HashSet<Invoice>();
            MemberPackageDetails = new HashSet<MemberPackageDetail>();
            Properties = new HashSet<Property>();
        }

        public int MemberId { get; set; }
        public int? RoleId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }
        public string Photo { get; set; }
        public DateTime CreateDate { get; set; }
        public string VerifyCode { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<Invoice> InvoiceMemberAs { get; set; }
        public virtual ICollection<Invoice> InvoiceMemberBs { get; set; }
        public virtual ICollection<MemberPackageDetail> MemberPackageDetails { get; set; }
        public virtual ICollection<Property> Properties { get; set; }
    }
}
