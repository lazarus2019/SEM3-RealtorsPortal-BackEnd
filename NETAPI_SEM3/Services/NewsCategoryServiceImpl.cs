using NETAPI_SEM3.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace NETAPI_SEM3.Services
{
	public class NewsCategoryServiceImpl : NewsCategoryService
	{
		#region Injection DB

		private ProjectSem3DBContext db;

		public NewsCategoryServiceImpl(ProjectSem3DBContext _db)
		{
			db = _db;
		}

		#endregion

		#region News Category CRUD

		public List<NewsCategory> getAllNewsCategory()
		{
			return db.NewsCategories.Where(newsCategory=> newsCategory.IsShow == true).ToList();
		}

		public int createNewsCategory(NewsCategory newsCategory)
		{
			try
			{
				db.NewsCategories.Add(newsCategory);
				db.SaveChanges();
				var lastId = db.NewsCategories.Max(newsCategory => newsCategory.NewsCategoryId);
				return lastId;
			}
			catch
			{
				return 0;
			}
		}

		public bool updateNewsCategory(NewsCategory newsCategory)
		{
			try
			{
				var oldNewsCategory = db.NewsCategories.Find(newsCategory.NewsCategoryId);
				if (oldNewsCategory != null)
				{
					oldNewsCategory.Name = newsCategory.Name;
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

		public bool deleteNewsCategory(int newsCategoryId)
		{
			try
			{
				var newsCategory = db.NewsCategories.Find(newsCategoryId);
				newsCategory.IsShow = false;
				db.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public NewsCategory findNewsCategory(int newsCategoryId)
		{
			return db.NewsCategories.Find(newsCategoryId);
		}

		#endregion

	}
}
