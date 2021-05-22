using NETAPI_SEM3.Entities;
using NETAPI_SEM3.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace NETAPI_SEM3.Services
{
	public class FAQServiceImpl : FAQService
	{
		#region Injection DB

		private ProjectSem3DBContext db;

		public FAQServiceImpl(ProjectSem3DBContext _db)
		{
			db = _db;
		}

		#endregion

		#region FAQ - CRUD

		public List<Faq> getAllFAQ()
		{
			return db.Faqs.ToList();
		}

		public Faq findFAQ(int faqId)
		{
			return db.Faqs.Find(faqId);
		}

		public bool createFAQ(Faq faq)
		{
			try
			{
				db.Faqs.Add(faq);
				db.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public bool deleteFAQ(int faqId)
		{
			try
			{
				var faq = db.Faqs.Find(faqId);
				db.Faqs.Remove(faq);
				db.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}

		}

		public bool updateFAQ(Faq faq)
		{
			try
			{
				var oldFaq = db.Faqs.Find(faq.FaqId);
				if (oldFaq != null)
				{
					oldFaq.Title = faq.Title;
					oldFaq.Description = faq.Description;
					db.SaveChanges();
					return true;
				}
				else
				{
					return false;
				}
			}
			catch
			{
				return false;
			}
		}
		#endregion
	}
}
