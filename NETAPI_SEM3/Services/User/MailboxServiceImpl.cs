using NETAPI_SEM3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETAPI_SEM3.Services.User
{
    public class MailboxServiceImpl : MailboxService
    {
        private DatabaseContext db;

        public MailboxServiceImpl(DatabaseContext _db)
        {
            db = _db;
        }
        public bool AddMailbox(Mailbox mail)
        {
            try
            {
                db.Mailboxes.Add(mail);
                db.SaveChanges();
                return true;
            }
            catch 
            {
                return false ;
                
            }
        }
    }
}
