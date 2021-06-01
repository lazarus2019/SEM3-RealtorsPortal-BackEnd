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
		public int getAllNews();
		public MyNews findNews(int newsId);
		public int createNews(News news);
		public bool updateNews(News news);
		public bool deleteNew(int newId);
		public bool updateStatus(News news);
		public List<MyNews> filterNewsPerPage(int page, string title, string category, string status, string sortDate);
		public int getAllFilterNews(string title, string category, string status, string sortDate);
		public List<Image> getGallery(int newsId);
		public List<MyNews> getNewsPerPage(int page);
	}
}
