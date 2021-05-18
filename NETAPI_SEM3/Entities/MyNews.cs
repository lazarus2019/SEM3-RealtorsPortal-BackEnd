using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETAPI_SEM3.Entities
{
	public class MyNews
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string CategoryName { get; set; }
		public DateTime? CreatedDate { get; set; }
		public string Status { get; set; }

		public string ThumbnailName { get; set; }
	}
}
