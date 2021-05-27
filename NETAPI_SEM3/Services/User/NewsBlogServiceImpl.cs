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

        public List<NewCategory> loadnewCategory()
        {
            var results = db.News
                 .OrderByDescending(n => n.CreatedDate)
                 .Take(6).Select(n => new NewCategory
                 {
                     NewsId = n.NewsId,
                     Title = n.Title,
                     Description = n.Description,
                     CreatedDate = n.CreatedDate,
                     Status = n.Status,
                     ThumbailName = db.Images.First(image => image.NewsId == n.NewsId).Name
                 }).Where(m=> m.Status.Equals("public")).ToList();
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
                Status = k.Status

            }).SingleOrDefault(p => p.NewsId == categoryId);
        }

        #region NewsCategory, Gallery, Thumbnail
        public List<Image> getGallery(int newsId)
        {
            return db.Images.Where(image => image.NewsId == newsId).ToList();
        }

        #endregion
    }

}

