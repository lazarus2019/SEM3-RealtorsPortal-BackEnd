using NETAPI_SEM3.Entities;
using NETAPI_SEM3.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace NETAPI_SEM3.Services.User
{
    public class IndexServiceImpl : IndexService
    {
        private DatabaseContext db;
        private UserService userService;
        private Setting setting;
        public IndexServiceImpl(DatabaseContext _db , UserService _userService)
        {
            db = _db;
            userService = _userService;
            setting = _userService.GetSetting(); 
        }

        public List<Category> LoadCategories()
        {
        var setting = userService.GetSetting(); 
            return db.Categories.ToList(); 
        }

        public List<Country> LoadCountries()
        {
            return db.Countries.ToList(); 
        }

        public List<PopularLocations> LoadPopularLocations()
        {
           
            return db.Cities.Select(
                c => new PopularLocations
                {
                    CityId = c.CityId,
                    Name = c.Name,
                    NumberProperties = c.Properties.Count()
                }).OrderByDescending( c=> c.NumberProperties).Take(setting.NumPopularLocation).ToList();
        }

        public List<NewProperty> LoadTopProperty()
        {
            var results = db.Properties
                .OrderByDescending(p => p.UploadDate)
                .OrderBy(p => p.Price)
                .OrderByDescending(p => p.Area)
                .Take(setting.NumTopProperty).Select(p => new NewProperty
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
                    Images = p.Images.ToList()
                })
                .ToList();

            return results;
            /*
                */
        }

       
    }
}
