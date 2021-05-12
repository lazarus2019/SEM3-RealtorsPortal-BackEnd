using NETAPI_SEM3.Entities;
using NETAPI_SEM3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETAPI_SEM3.Services
{
	public class DemoServiceImpl : DemoService
	{
		#region Injection DB

		private ProjectSem3DBContext db;

		public DemoServiceImpl(ProjectSem3DBContext _db)
		{
			db = _db;
		}

		public bool addNews(News news)
		{
			try
			{
				db.News.Add(news);
				db.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public bool deleteNew(int newId)
		{
			throw new NotImplementedException();
		}

		#endregion

		#region findAll

		public List<MyNews> getAllNews()
		{
			var listNews = db.News.Join(
				db.NewsCategories,
				news => news.CategoryId,
				category => category.Id,
				(news, category) => new MyNews
				{
					Id = news.Id,
					Title = news.Title,
					Description = news.Description,
					CategoryName = category.Name
				}).ToList();
			return listNews;
		}

		public bool updateNew(News news)
		{
			throw new NotImplementedException();
		}

		#endregion
	}
}
