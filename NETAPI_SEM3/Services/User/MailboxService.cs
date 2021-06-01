using NETAPI_SEM3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETAPI_SEM3.Services.User
{
    public interface MailboxService
    {
        public bool AddMailbox(Mailbox mail);
    }
}
