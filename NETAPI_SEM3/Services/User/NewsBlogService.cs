using NETAPI_SEM3.Entities;
using NETAPI_SEM3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETAPI_SEM3.Services.User
{
    public interface NewsBlogService
    {
        public int getIdNews();
        public List<CategoryNews> getAllNews(int page, int numNewsPerPage);
        public CategoryNews getAllNewsId(int categoryId);
        public List<CategoryNews> getAllNewsSearch(int page, string titles, int categoryId );
        public int getReasultNewsSearch(string titles, int categoryId);
     
        public List<NewsCategory> getAllNewsCategory();
        public List<Property> getAllProperty(int propertyID);
        public List<Image> getGallery(int newsId);
    }
}
