using System;
using System.Collections.Generic;

#nullable disable

namespace NETAPI_SEM3.Models
{
    public partial class Mailbox
    {
        public int MailId { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Message { get; set; }
        public int? PropertyId { get; set; }

        public virtual Property Property { get; set; }
    }
}
