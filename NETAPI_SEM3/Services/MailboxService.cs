using NETAPI_SEM3.Entities;
using NETAPI_SEM3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETAPI_SEM3.Services
{
	public interface MailboxService
	{
		public List<MailboxEntities> getMailboxByMemberId(int memberId);
		public List<MailboxEntities> getMailboxAdmin();

		public MailboxEntities findMailbox(int mailboxId);

		public bool createMailbox(Mailbox mailbox);

		public bool deleteMailbox(int mailboxId);

		public bool readMailbox(int mailboxId);

		public int getAmountMailboxUnread(int memberId);
		public int getAmountMailboxAdminUnread();

		public List<MailboxEntities> filterMail(int memberId, string sortDate, string status);
		public List<MailboxEntities> filterMailAdmin(string sortDate, string status);
	}
}
