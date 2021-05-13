using NETAPI_SEM3.Entities;
using NETAPI_SEM3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETAPI_SEM3.Services
{
	public interface NewsService
	{
		public List<MyNews> getAllNews();

		public bool createNews(News news);

		public bool updateNew(News news);

		public bool deleteNew(int newId);

		public List<MyNews> sortFilterNews(string title, string category, bool status);

		public List<NewsCategory> getAllNewsCategory();
	}
}
