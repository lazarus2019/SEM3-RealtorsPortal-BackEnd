using NETAPI_SEM3.Entities;
using NETAPI_SEM3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETAPI_SEM3.Services.User
{
    public class NewsBlogServiceImpl : NewsBlogService
    {
        private DatabaseContext db;
        public NewsBlogServiceImpl(DatabaseContext _db)
        {
            db = _db;
        }

        public List<News> loadnewCategory()
        {
            var results = db.News
                 .OrderByDescending(p => p.CreatedDate)
                 .Take(6).ToList();
            return results;
        }

        public NewCategory loadnewCategoryId(int categoryId)
        {
            return db.News.Select(k => new NewCategory 
            { 
                NewsId = k.NewsId,
                Description = k.Description,
                CategoryId = k.CategoryId,
                Title = k.Title,
                CreatedDate = k.CreatedDate,
                Status = k.Status,

            }).SingleOrDefault(p => p.CategoryId == categoryId);
        }

    }
}
