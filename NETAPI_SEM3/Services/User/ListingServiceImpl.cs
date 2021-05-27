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
                MemberType = "Chua fix dc ",
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
        public List<City> getCity(string countryId)
        {
            return db.Cities.Where(c => c.CountryId.Equals(countryId)).ToList();
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
                MemberType = "Chua fix" ,
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
        public List<NewProperty> SearchProperty(string keyword, int categoryId, string countryId)
        {
            
            var results = db.Properties
                .Where(p => p.Title.ToLower().Contains(keyword.Trim().ToLower()) ).ToList() 
                .Where(p => p.Category.CategoryId.Equals(categoryId)).ToList() 
                .Where(p => p.City.Country.CountryId.Equals(countryId))
                .Select(p => new NewProperty
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
                    Price = (double)p.Price,
                    RoomNumber = p.RoomNumber,
                    SoldDate = p.SoldDate,
                    UploadDate = p.UploadDate,
                    StatusId = p.StatusId,
                    StatusName = p.Status.Name,
                    Title = p.Title,
                    Type = p.Type,
                    Images = p.Images.ToList(),
                    
                })
                .ToList();


            return results;
        }
        public List<City> getAllCity()
        {
            return db.Cities.ToList(); 
        }

        public List<NewProperty> SearchPropertyListing(string keyword, int categoryId, string country, string city, string type, double area, int bed, int room, double price)
        {
            //key=all;country=all;city=all;cate=all;type=all;area=0;bed=0;room=0;price=1;pg=listing
            var properties = db.Properties.ToList(); 
            if( keyword != "all")
            {
                properties = properties.Where(p => p.Title.Contains(keyword.ToLower() )).ToList() ;
            }
            if( categoryId != 0)
            {
                properties = properties.Where(p => p.CategoryId == categoryId).ToList();
            }
            if( country != "all")
            {
                properties = properties.Where(p => p.City.Country.CountryId.Equals(country)).ToList();
            }
            if( city != "all")
            {
                properties = properties.Where(p => p.CityId.Equals(city)).ToList(); 
            }
            if( type != "all")
            {
                properties = properties.Where(p => p.Type.Equals(type)).ToList();
            }
            if( area != 0)
            {
                switch (area)
                {
                    case 1 :
                        properties = properties.Where(p => p.Area < 50).ToList();
                        break;
                   case 2 :
                        properties = properties.Where(p => p.Area >= 50 && p.Area < 100).ToList();
                        break;
                   case 3 :
                        properties = properties.Where(p => p.Area >= 100 && p.Area < 250 ).ToList();
                        break;
                   case 4 :
                        properties = properties.Where(p => p.Area >= 250 && p.Area < 500 ).ToList();
                        break;
                   case 5 :
                        properties = properties.Where(p => p.Area >500).ToList();
                        break;
                }
            }
            if( bed != 0 )
            {
                properties = properties.Where(p => p.BedNumber >= bed).ToList(); 
            }
            if( room != 0 )
            {
                properties = properties.Where(p => p.RoomNumber >= room).ToList();
            }
            if (price != 0)
            {
                switch (price)
                {
                    case 1:
                        properties = properties.Where(p => p.Price < 100).ToList();
                        break;
                    case 2:
                        properties = properties.Where(p => p.Price >= 100 && p.Price < 200).ToList();
                        break;
                    case 3:
                        properties = properties.Where(p => p.Price >= 200 && p.Price < 300).ToList();
                        break;
                    case 4:
                        properties = properties.Where(p => p.Price >= 300 && p.Price < 500).ToList();
                        break;
                    case 5:
                        properties = properties.Where(p => p.Price > 500).ToList();
                        break;
                }
            }
            return properties.Select(p => new NewProperty
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
                Price = (double)p.Price,
                RoomNumber = p.RoomNumber,
                SoldDate = p.SoldDate,
                UploadDate = p.UploadDate,
                StatusId = p.StatusId,
                StatusName = p.Status.Name,
                Title = p.Title,
                Type = p.Type,
                Images = p.Images.ToList(),

            })
                .ToList();
        }

        //public List<Property> search(string keyword, string location, string region, string type, double area, int bed, int room, double price)
        //{

        //}
    }
}
