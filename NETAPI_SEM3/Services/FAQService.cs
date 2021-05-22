using NETAPI_SEM3.Entities;
using NETAPI_SEM3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETAPI_SEM3.Services
{
	public interface FAQService
	{
		public List<Faq> getAllFAQ();

		public Faq findFAQ(int faqId);

		public bool createFAQ(Faq faq);

		public bool deleteFAQ(int faqId);

		public bool updateFAQ(Faq faq);
	}
}
