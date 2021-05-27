using NETAPI_SEM3.Entities;
using NETAPI_SEM3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETAPI_SEM3.Services.User
{
    public class CategoryServiceImpl : CategoryService
    {
        private DatabaseContext db;
        public CategoryServiceImpl(DatabaseContext _db)
        {
            db = _db;
        }

        public List<Category> getAllCategory()
        {
            return db.Categories.ToList();
        }

        public List<NewProperty> PropertyByCategory(int categoryId)
        {
            return db.Properties.Where(p => p.CategoryId == categoryId).Select(
                p => new NewProperty
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
                    MemberType = "Chua fix",
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
    }
}
