using System;
using System.Collections.Generic;

#nullable disable

namespace NETAPI_SEM3.Models
{
    public partial class Member
    {
        public Member()
        {
            Invoices = new HashSet<Invoice>();
            MemberPackageDetails = new HashSet<MemberPackageDetail>();
            Properties = new HashSet<Property>();
        }

        public int MemberId { get; set; }
        public string AccountId { get; set; }
        public string Position { get; set; }
        public string Email { get; set; }
        public string RoleId { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public bool Status { get; set; }
        public bool IsShowMail { get; set; }
        public string Photo { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<MemberPackageDetail> MemberPackageDetails { get; set; }
        public virtual ICollection<Property> Properties { get; set; }
    }
}
