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
        private Setting setting; 

        public CategoryServiceImpl(DatabaseContext _db)
        {
            db = _db;
            db = _db;
            GetSetting();
        }

        public Setting GetSetting()
        {
            setting = db.Settings.First();
            return setting;
        }
        public List<Category> getAllCategory()
        {
            return db.Categories.ToList();
        }

        public List<NewProperty> PropertyByCategory(int categoryId , int page)
        {
            var result = new List<NewProperty>();
            var skip = (page - 1) * setting.NumProperty; 

            if( page != 1)
            {
                result = db.Properties.Where(p => p.CategoryId == categoryId).Select(
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
                    MemberType = db.Roles.SingleOrDefault(r => r.Id.Equals(p.Member.RoleId)).Name,
                    Price = (double)p.Price,
                    RoomNumber = p.RoomNumber,
                    SoldDate = p.SoldDate,
                    UploadDate = p.UploadDate,
                    StatusId = p.StatusId,
                    StatusName = p.Status.Name,
                    Title = p.Title,
                    Type = p.Type,

                    Images = p.Images.Select(i => new NewImageProperty
                    {
                        ImageId = i.ImageId,
                        Name = i.Name,
                        PropertyId = i.PropertyId ?? default(int)
                    }).ToList()
                })
                    .Skip(skip).Take(setting.NumProperty).ToList();
            }
            else
            {
                result = db.Properties.Where(p => p.CategoryId == categoryId).Select(
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
                    MemberType = db.Roles.SingleOrDefault(r => r.Id.Equals(p.Member.RoleId)).Name,
                    Price = (double)p.Price,
                    RoomNumber = p.RoomNumber,
                    SoldDate = p.SoldDate,
                    UploadDate = p.UploadDate,
                    StatusId = p.StatusId,
                    StatusName = p.Status.Name,
                    Title = p.Title,
                    Type = p.Type,

                    Images = p.Images.Select(i => new NewImageProperty
                    {
                        ImageId = i.ImageId,
                        Name = i.Name,
                        PropertyId = i.PropertyId ?? default(int)
                    }).ToList()
                })
                    .Take(setting.NumProperty).ToList();
            }
            return result; 
            
        }
        public int PropertyByCategoryCount(int categoryId)
        {
            return db.Properties.Where(p => p.CategoryId == categoryId).Count(); 
        }
   
    }
}
