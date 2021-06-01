using NETAPI_SEM3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETAPI_SEM3.Services
{
	public interface NewsCategoryService
	{
		public List<NewsCategory> getAllNewsCategory();
		public int createNewsCategory(NewsCategory newsCategory);

		public bool updateNewsCategory(NewsCategory newsCategory);
		public bool deleteNewsCategory(int newsCategoryId);
		public NewsCategory findNewsCategory(int newsCategoryId);
	}
}
