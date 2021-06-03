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
                 .Select(n => new CategoryNews
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

        public List<CategoryNews> getAllNews(int page, int numNewsPerPage)
        {
            var test = db.Settings.First().NumNews;
            var start = test * (page - 1);
            var results = db.News.Select(n => new CategoryNews
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

        public CategoryNews getAllNewsId(int categoryId)
        {
            return db.News.Select(k => new CategoryNews
            {
                NewsId = k.NewsId,
                Description = k.Description,
                CategoryId = k.CategoryId,
                Title = k.Title,
                CreatedDate = k.CreatedDate,
                Status = k.Status

            }).SingleOrDefault(p => p.NewsId == categoryId);
        }

        public List<CategoryNews> getAllNewsSearch(int page, string titles, int categoryId)
        {
            var test = db.Settings.First().NumNews;
            var start = test * (page - 1);
            var news = db.News.Where(p => p.CategoryId.Equals(categoryId)).ToList();
            if (titles != "all")
            {
                news = news.Where(p => p.Title.ToLower().Contains(titles.Trim().ToLower())).ToList();
            }

            var newss = news.Select(p => new CategoryNews
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
            var newss = news.Select(p => new CategoryNews
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

        public List<PropertyNews> getAllProperty(int propertyID)
        {
            return db.Properties.Where(k => k.MemberId == propertyID)

             .Select(k => new PropertyNews
             {
                 PropertyId = k.PropertyId,
                 Title = k.Title,
                 CityId = k.CityId,
                 Address = k.Address,
                 GoogleMap = k.GoogleMap,
                 Price = (double)k.Price,
                 BedNumber = k.BedNumber,
                 RoomNumber = k.RoomNumber,
                 Area = k.Area,
                 UploadDate = k.UploadDate,
                 BuildYear = k.BuildYear,
                 StatusId = k.StatusId,
                 Type = k.Type,
                 CategoryId = k.CategoryId,
                 MemberId = k.MemberId,
                 Description = k.Description,
                 ThumbailName = db.Images.First(image => image.PropertyId == k.PropertyId).Name
             }).OrderByDescending(k => k.UploadDate).Take(3).ToList();
        }

        #region NewsCategory, Gallery, Thumbnail
        public List<Image> getGallery(int newsId)
        {
            return db.Images.Where(image => image.NewsId == newsId).ToList();
        }

        
        #endregion
    }

}

