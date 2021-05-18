using NETAPI_SEM3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETAPI_SEM3.Services
{
	public class NewsImageServiceImpl : NewsImageService
	{
		#region Injection DB

		private ProjectSem3DBContext db;

		public NewsImageServiceImpl(ProjectSem3DBContext _db)
		{
			db = _db;
		}

		#endregion
		public bool createNewsImage(NewsImage image)
		{
			try
			{
				db.NewsImages.Add(image);
				db.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}
	}
}
