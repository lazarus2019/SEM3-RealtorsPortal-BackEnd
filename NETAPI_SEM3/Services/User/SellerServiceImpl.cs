using NETAPI_SEM3.Entities;
using NETAPI_SEM3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETAPI_SEM3.Services.User
{
    public class SellerServiceImpl : SellerService
    {
        private DatabaseContext db;
        public SellerServiceImpl(DatabaseContext _db)
        {
            db = _db;
        }

        public List<Member> getAllAgent(int page)
        {
            var test = db.Settings.First().NumPopularAgent;
            var start = test * (page - 1);
            var result1 = db.Members.Where(m => m.RoleId.Equals("2"))
                .ToList();
            result1 = result1.Skip(start).Take(test).ToList();
            return result1;

            
        }
        public int getIdAgent()
        {
            var result1 = db.Members.Where(m => m.RoleId.Equals("2"))
                .ToList();
            return result1.Count;
        }

        //
        public List<Member> getAllSeller(int page)
        {
            var test = db.Settings.First().NumPopularAgent;
            var start = test * (page - 1);
            var result1 = db.Members.Where(m => m.RoleId.Equals("3"))
                .ToList();
            result1 = result1.Skip(start).Take(test).ToList();
            return result1;


        }
        public int getIdSeller()
        {
            var result1 = db.Members.Where(m => m.RoleId.Equals("3"))
                .ToList();
            return result1.Count;
        }

        // Load 1 Seller / Agent + Property By Id
        public NewMember SellerDetails(int sellerId)
        {
            return db.Members.Select( m => new NewMember
            {
                MemberId = m.MemberId ,
                FullName = m.FullName,
                RoleId = m.RoleId,
                Username = m.Username,
                Phone = m.Phone,
                Status = m.Status,
                Photo = m.Photo,
                Description = m.Description,
                CreateDate = m.CreateDate,
              

            }).SingleOrDefault(p => p.MemberId == sellerId);
        }

        //Get Image
        #region NewsCategory, Gallery, Thumbnail
        public List<Image> getGallery(int newsId)
        {
            return db.Images.Where(image => image.NewsId == newsId).ToList();
        }
        #endregion
        public List<Property> LoadPropertyId(int propertyId)
        {
             return db.Properties.Where(k => k.MemberId == propertyId).ToList();
            /*
             .Select(k => new NewProperty
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
            }).ToList();
            */

        }




    }
}
