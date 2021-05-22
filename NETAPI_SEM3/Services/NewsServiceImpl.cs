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

		#endregion

		#region News CRUD

		public int createNews(News news)
		{
			try
			{
				db.News.Add(news);
				db.SaveChanges();
				var lastId = db.News.Max(news => news.NewsId);
				return lastId;
			}
			catch
			{
				return 0;
			}
		}

		public List<MyNews> getAllNews()
		{
			var listNews = db.News.Join(
				db.NewsCategories,
				news => news.CategoryId,
				category => category.NewsCategoryId,
				(news, category) => new MyNews
				{
					NewsId = news.NewsId,
					Title = news.Title,
					Description = news.Description,
					CreatedDate = news.CreatedDate,
					Status = news.Status,
					CategoryName = category.Name,
					ThumbnailName = db.Images.First(image => image.NewsId == news.NewsId).Name
				}).ToList();
			return listNews;
		}

		public MyNews findNews(int newsId)
		{
			var news = db.News.Find(newsId);
			MyNews newsReturn = new MyNews
			{
				NewsId = news.NewsId,
				Description = news.Description,
				CategoryId = news.CategoryId,
				CategoryName = news.Category.Name,
				CreatedDate = news.CreatedDate,
				Status = news.Status,
				Title = news.Title
			};
			return newsReturn;
		}

		public bool updateNews(News news)
		{
			try
			{
				var oldNews = db.News.Find(news.NewsId);
				if (oldNews != null)
				{
					oldNews.Description = news.Description;
					oldNews.Title = news.Title;
					oldNews.CategoryId = news.CategoryId;
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

		#region News Sort & Filter

		public List<MyNews> sortFilterNews(string title, string category, string status)
		{
			var rawListNews = new List<News>();
			if (title.Equals(".all"))
			{
				rawListNews = db.News.ToList();
			}
			else
			{
				rawListNews = db.News.Where(news => news.Title.ToLower().Contains(title.ToLower())).ToList();
			}
			if (!category.Equals("all"))
			{
				rawListNews = rawListNews.Where(news => news.Category.Name.ToLower().Equals(category.ToLower())).ToList();
			}
			if (!status.Equals("all"))
			{
				rawListNews = rawListNews.Where(news => news.Status.ToLower().Equals(status.ToLower())).ToList();
			}
			var listNews = rawListNews.Join(
					db.NewsCategories,
					news => news.CategoryId,
					category => category.NewsCategoryId,
					(news, category) => new MyNews
					{
						NewsId = news.NewsId,
						Title = news.Title,
						Description = news.Description,
						CreatedDate = news.CreatedDate,
						Status = news.Status,
						CategoryName = category.Name
					}).ToList();
			return listNews;

		}

		#endregion

		#region NewsCategory, Gallery, Thumbnail

		public List<NewsCategory> getAllNewsCategory()
		{
			return db.NewsCategories.ToList();
		}

		public List<Image> getGallery(int newsId)
		{
			return db.Images.Where(image => image.NewsId == newsId).ToList();
		}

		#endregion
	}
}
