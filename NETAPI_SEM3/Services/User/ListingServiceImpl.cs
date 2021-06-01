using Microsoft.AspNetCore.Identity;
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
        private Setting setting;


        public ListingServiceImpl(DatabaseContext _db, UserService _userService)
        {
            db = _db;
            GetSetting(); 
        }

        public Setting GetSetting()
        {
            setting = db.Settings.First();
            return setting;
        }
        public IdentityRole GetRole(string RoleId)
        {
            return db.Roles.SingleOrDefault(r => r.Id.Equals(RoleId)); // chỗ  nay ne viet 
        }
        public List<NewProperty> GetAllListing(int page)
        {
            var listing = new List<NewProperty>() ; 
            var skip = (page - 1) * setting.NumProperty;
            if ( page != 1 )
            {
                listing = db.Properties.Where(p => p.StatusId == 1 || p.StatusId == 5).Select(p => new NewProperty
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
                    MemberPhoto = p.Member.Photo ,                    
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
                .Skip(skip)
                .Take(setting.NumProperty).ToList();
            }
            else
            {
                listing  = db.Properties.Where(p => p.StatusId == 1 || p.StatusId == 5).Select(p => new NewProperty
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
                MemberPhoto = p.Member.Photo,
                //MemberType = "AbC" ,
                Price = (double)p.Price,
                RoomNumber = p.RoomNumber,
                SoldDate = p.SoldDate,
                UploadDate = p.UploadDate,
                StatusId = p.StatusId,
                StatusName = p.Status.Name,
                Title = p.Title,
                Type = p.Type,                
                Images = p.Images.Select( i => new NewImageProperty
                {
                    ImageId = i.ImageId ,
                    Name = i.Name ,
                    PropertyId = i.PropertyId ?? default(int)
                }).ToList()
                })
                .Take(setting.NumProperty)
                .ToList();
            }
            return listing; 
        }
        public List<Category> getCategory()
        {
            return db.Categories.ToList();
        }
        public List<Region> getRegion()
        {
            return db.Regions.ToList();
        }
        public List<NewCity> getCity(int countryId)
        {
            return db.Cities.Where(c => c.CountryId == countryId).Select( c => new NewCity
            {
                CountryId = c.CountryId , 
                Name = c.Name ,
                CityId  = c.CityId 
            }).ToList();
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
                MemberEmail = p.Member.Email ,
                MemberPhone = p.Member.Phone , 
                MemberPhoto = p.Member.Photo , 
                MemberType = db.Roles.SingleOrDefault(r => r.Id.Equals(p.Member.RoleId)).Name,
                Price = (double)p.Price,
                RoomNumber = p.RoomNumber,
                SoldDate = p.SoldDate,
                UploadDate = p.UploadDate,
                BuildYear = p.BuildYear,
                StatusId = p.StatusId,
                StatusName = p.Status.Name,
                Title = p.Title,
                Type = p.Type,             
                Images = p.Images.Select(i => new NewImageProperty
                {
                    ImageId = i.ImageId,
                    Name = i.Name,
                    PropertyId = i.PropertyId ?? default(int)
                }).ToList() , 
                
            }).SingleOrDefault(p => p.PropertyId == propertyId);
        }
        public List<NewProperty> SearchProperty( string keyword, int categoryId, int countryId , int page)
        {
            var skip = (page - 1) * setting.NumProperty;
            var properties = db.Properties.ToList();
            if (keyword != "all")
            {
                properties = properties.Where(p => p.Title.Contains(keyword.ToLower())).ToList();
            }
            if (categoryId != 0)
            {
                properties = properties.Where(p => p.CategoryId == categoryId).ToList();
            }
            if (countryId != 0 )
            {
                properties = properties.Where(p => p.City.CountryId == countryId).ToList();
            }
            if( page == 1 )
            {
                return properties.Where(p => p.StatusId == 1 || p.StatusId == 5).Select(p => new NewProperty
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
                    MemberType = db.Roles.SingleOrDefault(r => r.Id.Equals(p.Member.RoleId)).Name ,
                    MemberName = p.Member.FullName,
                    MemberPhoto = p.Member.Photo,
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
            else
            {
                return properties.Where(p => p.StatusId == 1 || p.StatusId == 5).Select(p => new NewProperty
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
                    MemberType = db.Roles.SingleOrDefault(r => r.Id.Equals(p.Member.RoleId)).Name , 
                    MemberName = p.Member.FullName,
                    MemberPhoto = p.Member.Photo,
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

        }
        public List<NewCity> getAllCity()
        {
            return db.Cities.Select( c => new NewCity {
                CityId = c.CityId ,
                Name = c.Name ,
                CountryId = c.CountryId 
            }).ToList();
        }

        public List<NewProperty> SearchPropertyListing( string keyword, int categoryId, int countryId, int city, string type, double area, int bed, int room, double price , int page)
        {
            //key=all;country=all;city=all;cate=all;type=all;area=0;bed=0;room=0;price=1;pg=listing
            var properties = db.Properties.ToList();
            if (keyword != "all")
            {
                properties = properties.Where(p => p.Title.Contains(keyword.ToLower())).ToList();
            }
            if (categoryId != 0)
            {
                properties = properties.Where(p => p.CategoryId == categoryId).ToList();
            }
            if (countryId != 0)
            {
                properties = properties.Where(p => p.City.Country.CountryId.Equals(countryId)).ToList();
            }
            if (city != 0 )
            {
                properties = properties.Where(p => p.CityId.Equals(city)).ToList();
            }
            if (type != "all")
            {
                properties = properties.Where(p => p.Type.Equals(type)).ToList();
            }
            if (area != 0)
            {
                switch (area)
                {
                    case 1:
                        properties = properties.Where(p => p.Area < 50).ToList();
                        break;
                    case 2:
                        properties = properties.Where(p => p.Area >= 50 && p.Area < 100).ToList();
                        break;
                    case 3:
                        properties = properties.Where(p => p.Area >= 100 && p.Area < 250).ToList();
                        break;
                    case 4:
                        properties = properties.Where(p => p.Area >= 250 && p.Area < 500).ToList();
                        break;
                    case 5:
                        properties = properties.Where(p => p.Area > 500).ToList();
                        break;
                }
            }
            if (bed != 0)
            {
                properties = properties.Where(p => p.BedNumber >= bed).ToList();
            }
            if (room != 0)
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
            return properties.Where(p => p.StatusId == 1 || p.StatusId == 5).Select(p => new NewProperty
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
                MemberType = db.Roles.SingleOrDefault(r => r.Id.Equals(p.Member.RoleId)).Name ,
                MemberName = p.Member.FullName,
                MemberPhoto = p.Member.Photo ,
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
                .Skip((page - 1) * setting.NumProperty).Take(setting.NumProperty).ToList();
        }

        public List<IdentityRole> GetAllRole()
        {
            return db.Roles.ToList();
        }

        public int GetListingCount()
        {
            return db.Properties.Where(p => p.StatusId == 1 || p.StatusId == 5).Count();
        }

        public int SearchPropertyCount(string keyword, int categoryId, int countryId)
        {
            return db.Properties
                    .Where(p => p.Title.ToLower().Contains(keyword.Trim().ToLower())).ToList()
                    .Where(p => p.Category.CategoryId.Equals(categoryId)).ToList()
                    .Where(p => p.City.Country.CountryId.Equals(countryId)).Count();
        }

        public int SearchPropertyListingCount(string keyword, int categoryId, int countryId, int city, string type, double area, int bed, int room, double price)
        {
            var properties = db.Properties.ToList();
            if (keyword != "all")
            {
                properties = properties.Where(p => p.Title.Contains(keyword.ToLower())).ToList();
            }
            if (categoryId != 0)
            {
                properties = properties.Where(p => p.CategoryId == categoryId).ToList();
            }
            if (countryId != 0)
            {
                properties = properties.Where(p => p.City.Country.CountryId.Equals(countryId)).ToList();
            }
            if (city != 0 )
            {
                properties = properties.Where(p => p.CityId.Equals(city)).ToList();
            }
            if (type != "all")
            {
                properties = properties.Where(p => p.Type.Equals(type)).ToList();
            }
            if (area != 0)
            {
                switch (area)
                {
                    case 1:
                        properties = properties.Where(p => p.Area < 50).ToList();
                        break;
                    case 2:
                        properties = properties.Where(p => p.Area >= 50 && p.Area < 100).ToList();
                        break;
                    case 3:
                        properties = properties.Where(p => p.Area >= 100 && p.Area < 250).ToList();
                        break;
                    case 4:
                        properties = properties.Where(p => p.Area >= 250 && p.Area < 500).ToList();
                        break;
                    case 5:
                        properties = properties.Where(p => p.Area > 500).ToList();
                        break;
                }
            }
            if (bed != 0)
            {
                properties = properties.Where(p => p.BedNumber >= bed).ToList();
            }
            if (room != 0)
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
            return properties.Where(p => p.StatusId == 1 || p.StatusId == 5).Count();
        }

        public List<NewProperty> GetPopularPost(int memberId)
        {

           return db.Properties.Where(p => p.StatusId == 1 || p.StatusId == 5).Where( p => p.MemberId == memberId).Select(p => new NewProperty
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
                MemberPhoto = p.Member.Photo,
               Images = p.Images.Select(i => new NewImageProperty
                    {
                        ImageId = i.ImageId,
                        Name = i.Name,
                        PropertyId = i.PropertyId ?? default(int)
                    }).ToList()
                }).ToList();
        }

        public List<NewImageProperty> GetGallery(int propertyId)
        {
            return db.Images.Where(i => i.PropertyId == propertyId)
                .Select( i => new NewImageProperty
                {
                    ImageId = i.ImageId , 
                    Name = i.Name , 
                    PropertyId = i.PropertyId ?? default(int)
                })
                .ToList();
        }

    }
}
