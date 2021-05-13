using NETAPI_SEM3.Entities;
using NETAPI_SEM3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETAPI_SEM3.Services
{
	public class NewsServiceImpl : NewsService
	{
		#region Injection DB

		private ProjectSem3DBContext db;

		public NewsServiceImpl(ProjectSem3DBContext _db)
		{
			db = _db;
		}

		public bool createNews(News news)
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
			try
			{
				var news = db.News.Find(newId);
				db.News.Remove(news);
				db.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
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
					CreatedDate = news.CreatedDate,
					Status = news.Status,
					CategoryName = category.Name
				}).ToList();
			return listNews;
		}

		public List<NewsCategory> getAllNewsCategory()
		{
			return db.NewsCategories.ToList();
		}

		public List<MyNews> sortFilterNews(string title, string category, bool status)
		{
			throw new NotImplementedException();
		}

		public bool updateNew(News news)
		{
			throw new NotImplementedException();
		}

		#endregion
	}
}
