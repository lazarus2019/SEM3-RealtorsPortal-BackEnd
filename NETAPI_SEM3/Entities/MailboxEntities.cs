using System;
using System.Collections.Generic;

namespace NETAPI_SEM3.Entities
{
    public class MailboxEntities
    {
        public int MailId { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public int? PropertyId { get; set; }
        public bool IsRead { get; set; }
        public DateTime Time { get; set; }
    }
}
