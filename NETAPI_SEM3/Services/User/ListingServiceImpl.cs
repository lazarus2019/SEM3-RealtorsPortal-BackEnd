using NETAPI_SEM3.Entities;
using NETAPI_SEM3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETAPI_SEM3.Services.User
{
    public class ListingServiceImpl : ListingService
    {
        private DatabaseContext db;
        public ListingServiceImpl(DatabaseContext _db)
        {
            db = _db;
        }
        public List<NewProperty> GetAllListing()
        {
            return db.Properties.Select(p => new NewProperty
            {
                PropertyId = p.PropertyId,
                Address = p.Address,
                Area = p.Area,
                BedNumber = p.BedNumber,
                CategoryId = p.CategoryId,
                CategoryName = p.Category.Name,
                CityId = p.CityId,
                CityName = p.City.Name,
                Description = p.Description,
                MemberId = p.MemberId,
                MemberName = p.Member.FullName,
                MemberType = p.Member.Role.Name,
                Price = (double)p.Price,
                RoomNumber = p.RoomNumber,
                SoldDate = p.SoldDate,
                UploadDate = p.UploadDate,
                StatusId = p.StatusId,
                StatusName = p.Status.Name,
                Title = p.Title,
                Type = p.Type,

                Images = p.Images.ToList()
            }).ToList(); 
        }

        public List<Category> getCategory()
        {
            return db.Categories.ToList(); 
        }

        public List<Region> getRegion()
        {
            return db.Regions.ToList();
        }

        public NewProperty PropertyDetail(int propertyId)
        {
            return db.Properties.Select(p => new NewProperty
            {
                PropertyId = p.PropertyId,
                Address = p.Address,
                GoogleMap = p.GoogleMap,
                Area = p.Area,
                BedNumber = p.BedNumber,
                CategoryId = p.CategoryId,
                CategoryName = p.Category.Name,
                CityId = p.CityId,
                CityName = p.City.Name,
                Description = p.Description,
                MemberId = p.MemberId,
                MemberName = p.Member.FullName,
                MemberType = p.Member.Role.Name,
                Price = (double)p.Price,
                RoomNumber = p.RoomNumber,
                SoldDate = p.SoldDate,
                UploadDate = p.UploadDate,
                BuildYear = p.BuildYear,
                StatusId = p.StatusId,
                StatusName = p.Status.Name,
                Title = p.Title,
                Type = p.Type,

                Images = p.Images.ToList()
            }).SingleOrDefault( p => p.PropertyId == propertyId ); 
        }

        //public List<Property> search(string keyword, string location, string region, string type, double area, int bed, int room, double price)
        //{

        //}
    }
}
