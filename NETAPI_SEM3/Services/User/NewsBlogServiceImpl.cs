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

        public int getIdNews()
        {
            var results = db.News
                 .Select(n => new NewCategory
                 {
                     NewsId = n.NewsId,
                     Title = n.Title,
                     Description = n.Description,
                     CreatedDate = n.CreatedDate,
                     Status = n.Status,
                     ThumbailName = db.Images.First(image => image.NewsId == n.NewsId).Name
                 }).Where(m => m.Status.Equals("public")).ToList();
            return results.Count;
        }

        public List<NewCategory> getAllNews(int page, int numNewsPerPage)
        {
            var test = db.Settings.First().NumNews;
            var start = test * (page - 1);
            var results = db.News.Select(n => new NewCategory
            {
                NewsId = n.NewsId,
                Title = n.Title,
                Description = n.Description,
                CreatedDate = n.CreatedDate,
                Status = n.Status,
                ThumbailName = db.Images.First(image => image.NewsId == n.NewsId).Name
            }).Where(m => m.Status.Equals("public")).ToList();
            results = results.Skip(start).Take(test).ToList();
            results = results.OrderByDescending(n => n.CreatedDate).ToList();
            return results;
        }

        public NewCategory getAllNewsId(int categoryId)
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

        public List<NewCategory> getAllNewsSearch(int page, string titles, int categoryId)
        {
            var test = db.Settings.First().NumNews;
            var start = test * (page - 1);
            var news = db.News.Where(p => p.CategoryId.Equals(categoryId)).ToList();
            if (titles != "all")
            {
                news = news.Where(p => p.Title.ToLower().Contains(titles.Trim().ToLower())).ToList();
            }

            var newss = news.Select(p => new NewCategory
            {
                NewsId = p.NewsId,
                Description = p.Description,
                CategoryId = p.CategoryId,
                Title = p.Title,
                CreatedDate = p.CreatedDate,
                Status = p.Status,
                ThumbailName = db.Images.First(image => image.NewsId == p.NewsId).Name
            }).ToList();
            newss = newss.Skip(start).Take(test).ToList();
            return newss;
        }
        public int getReasultNewsSearch(string titles, int categoryId)
        {
            var news = db.News.Where(p => p.CategoryId.Equals(categoryId)).ToList();
            if (titles != "all")
            {
                news = news.Where(p => p.Title.ToLower().Contains(titles.Trim().ToLower())).ToList();
            }
            var newss = news.Select(p => new NewCategory
            {
                NewsId = p.NewsId,
                Description = p.Description,
                CategoryId = p.CategoryId,
                Title = p.Title,
                CreatedDate = p.CreatedDate,
                Status = p.Status,
                ThumbailName = db.Images.First(image => image.NewsId == p.NewsId).Name
            }).ToList();
            return newss.Count;

        }

        public List<NewsCategory> getAllNewsCategory()
        {
            return db.NewsCategories.ToList();
        }

        public List<Property> getAllProperty(int propertyID)
        {
            return db.Properties.Where(k => k.MemberId == propertyID).OrderByDescending(k=> k.UploadDate).Take(3).ToList();
        }

        #region NewsCategory, Gallery, Thumbnail
        public List<Image> getGallery(int newsId)
        {
            return db.Images.Where(image => image.NewsId == newsId).ToList();
        }

        
        #endregion
    }

}

