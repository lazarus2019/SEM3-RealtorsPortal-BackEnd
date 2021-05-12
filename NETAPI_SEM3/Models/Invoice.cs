using System;
using System.Collections.Generic;

#nullable disable

namespace NETAPI_SEM3.Models
{
    public partial class Invoice
    {
        public int InvoiceId { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public decimal Total { get; set; }
        public int PaymentId { get; set; }
        public string Status { get; set; }
        public int MemberAId { get; set; }
        public int MemberBId { get; set; }
        public int PropertyId { get; set; }

        public virtual Member MemberA { get; set; }
        public virtual Member MemberB { get; set; }
        public virtual Payment Payment { get; set; }
        public virtual Property Property { get; set; }
    }
}
