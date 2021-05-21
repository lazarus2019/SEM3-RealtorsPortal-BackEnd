using NETAPI_SEM3.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

		#region News Image - Create & Delete
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

		public bool deleteNewsImage(int newsImageId)
		{
			try
			{
				var newsImage = db.NewsImages.Find(newsImageId);
				db.NewsImages.Remove(newsImage);
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
