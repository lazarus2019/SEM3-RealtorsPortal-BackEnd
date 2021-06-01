using NETAPI_SEM3.Entities;
using NETAPI_SEM3.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace NETAPI_SEM3.Services
{
	public class MailboxServiceImpl : MailboxService
	{
		#region Injection DB

		private ProjectSem3DBContext db;

		public MailboxServiceImpl(ProjectSem3DBContext _db)
		{
			db = _db;
		}
		#endregion

		#region MailBox CRUD
		public bool createMailbox(Mailbox mailbox)
		{
			try
			{
				db.Mailboxes.Add(mailbox);
				db.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public bool deleteMailbox(int mailboxId)
		{
			try
			{
				var mailbox = db.Mailboxes.Find(mailboxId);
				db.Mailboxes.Remove(mailbox);
				db.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public MailboxEntities findMailbox(int mailboxId)
		{
			var mailbox = db.Mailboxes.Find(mailboxId);
			var mailboxResult = new MailboxEntities();
			mailboxResult.MailId = mailbox.MailId;
			mailboxResult.Message = mailbox.Message;
			mailboxResult.PropertyId = mailbox.PropertyId;
			mailboxResult.Phone = mailbox.Phone;
			mailboxResult.Email = mailbox.Email;
			mailboxResult.IsRead = mailbox.IsRead;
			mailboxResult.FullName = mailbox.FullName;
			mailboxResult.Time = mailbox.Time;
			return mailboxResult;
		}

		public int getAmountMailboxUnread(int memberId)
		{
			var properties = db.Properties.Where(property => property.MemberId == memberId).ToList();
			var result = 0;
			foreach (var property in properties)
			{
				var mailbox = db.Mailboxes.Where(mailBox => mailBox.PropertyId == property.PropertyId && mailBox.IsRead == false).ToList();
				result += mailbox.Count;
			}
			return result;
		}

		public List<MailboxEntities> getMailboxByMemberId(int memberId)
		{
			var properties = db.Properties.Where(property => property.MemberId == memberId).ToList();

			var listMailbox = new List<MailboxEntities>();
			foreach (var property in properties)
			{
				var mailbox = db.Mailboxes.Where(mailBox => mailBox.PropertyId == property.PropertyId).Select(mail => new MailboxEntities
				{
					MailId = mail.MailId,
					Message = mail.Message,
					PropertyId = mail.PropertyId,
					Phone = mail.Phone,
					Email = mail.Email,
					IsRead = mail.IsRead,
					FullName = mail.FullName,
					Time = mail.Time
				}).ToList();

				mailbox.ForEach(mail => listMailbox.Add(mail));
			}
			listMailbox = listMailbox.OrderByDescending(mailbox => mailbox.Time).ToList();
			return listMailbox;
		}

		#endregion

		#region Change Status & Filter

		public List<MailboxEntities> filterMail(int memberId, string sortDate, string status)
		{

			var listMailbox = getMailboxByMemberId(memberId);

			if (!status.Equals("all"))
			{
				listMailbox = listMailbox.Where(mailbox => mailbox.IsRead.ToString().Equals(status)).ToList();
			}

			if (sortDate.Equals("asc"))
			{
				listMailbox = listMailbox.OrderBy(mailbox => mailbox.Time).ToList();
			}
			if (sortDate.Equals("desc"))
			{
				listMailbox = listMailbox.OrderByDescending(mailbox => mailbox.Time).ToList();
			}

			return listMailbox;
		}

		public bool readMailbox(int mailboxId)
		{
			try
			{
				var mailbox = db.Mailboxes.Find(mailboxId);
				mailbox.IsRead = true;
				db.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		#endregion
	}
}
