using Microsoft.EntityFrameworkCore;
using NETAPI_SEM3.Models;
using NETAPI_SEM3.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETAPI_SEM3.Services
{
    public class PropertyServiceImpl : PropertyService
    {
        private readonly DatabaseContext _db;

        public PropertyServiceImpl(DatabaseContext db)
        {
            this._db = db;
        }

        public bool DeleteProperty(int id)
        {
            try
            {
                var property = _db.Properties.Find(id);
                _db.Properties.Remove(property);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<Property> GetAllPropertyPage(int page)
        {
            var start = 10 * (page - 1);
            var listProperty = _db.Properties
             .Include(p => p.Member)
             .Include(p => p.Category)
             .Include(p => p.Status)
             .Include(p => p.City)
             .ThenInclude(ci => ci.Country)
             .ThenInclude(co => co.Region)
             .Include(p => p.Images)
             .ToList();
            listProperty = listProperty.Skip(start).Take(10).ToList();
            return listProperty;

        }

        public int GetAllProperty()
        {
            return _db.Properties
             .Include(p => p.Member)
             .Include(p => p.Category)
             .Include(p => p.Status)
             .Include(p => p.Images)
             .Include(p => p.City)
             .ThenInclude(ci => ci.Country)
             .ThenInclude(co => co.Region)
             .Count();
        }
        public IEnumerable<Property> GetAllPropertyPageByMember(int memberId, int page)
        {
            var start = 10 * (page - 1);
            var listProperty = _db.Properties
             .Include(p => p.Member)
             .Include(p => p.Category)
             .Include(p => p.Status)
             .Include(p => p.Images)
             .Include(p => p.City)
             .ThenInclude(ci => ci.Country)
             .ThenInclude(co => co.Region)
             .Where(p => p.MemberId == memberId)
             .ToList();
            listProperty = listProperty.Skip(start).Take(10).ToList();
            return listProperty;

        }

        public int GetAllPropertyByMember(int memberId)
        {
            return _db.Properties
             .Include(p => p.Member)
             .Include(p => p.Category)
             .Include(p => p.Status)
             .Include(p => p.Images)
             .Include(p => p.City)
             .ThenInclude(ci => ci.Country)
             .ThenInclude(co => co.Region)
             .Where(p => p.MemberId == memberId)
             .Count();
        }

        public Property GetPropertyByid(int id)
        {
            try
            {
                return _db.Properties
             .Include(p => p.Member)
             .Include(p => p.Category)
             .Include(p => p.Status)
             .Include(p => p.Images)
             .Include(p => p.City)
             .ThenInclude(ci => ci.Country)
             .ThenInclude(co => co.Region)
             .SingleOrDefault(p => p.PropertyId == id);
                //return _db.Properties.Select(p => new PropertyViewModel
                //{
                //    PropertyId = p.PropertyId,
                //    Address = p.Address,
                //    Area = p.Area,
                //    BedNumber = p.BedNumber,
                //    CategoryId = p.CategoryId,
                //    CategoryName = p.Category.Name,
                //    CityId = p.CityId,
                //    CityName = p.City.Name,
                //    CityCountryId = p.City.Country.CountryId,
                //    CityCountryName = p.City.Country.Name,
                //    CityCountryRegionId = p.City.Country.Region.RegionId,
                //    CityCountryRegionName = p.City.Country.Region.Name,
                //    Description = p.Description,
                //    MemberId = p.MemberId,
                //    MemberFullName = p.Member.FullName,
                //    Email = p.Member.Email,
                //    //emberPhone = p.Member.Phone,
                //    //MemberType = _db.Roles.SingleOrDefault(r => r.Id.Equals(p.Member.RoleId)).Name,
                //    Price = (decimal)p.Price,
                //    RoomNumber = p.RoomNumber,
                //    SoldDate = p.SoldDate,
                //    UploadDate = p.UploadDate,
                //    StatusId = p.StatusId,
                //    StatusName = p.Status.Name,
                //    Title = p.Title,
                //    Type = p.Type,


                //}).SingleOrDefault(p => p.PropertyId == id);
            }
            catch
            {
                return null;
            }

        }

        public bool UpdateProperty(Property property)
        {
            try
            {
                _db.Properties.Update(property);
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public int CreateProperty(Property property)
        {
            try
            {
                if (property != null)
                {
                    _db.Properties.Add(property);
                    _db.SaveChanges();
                }
                return property.PropertyId;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }

        public bool UpdateStatus(int id, int statusId)
        {
            try
            {
                var property = _db.Properties.Find(id);
                property.StatusId = statusId;
                _db.Properties.Update(property);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<Property> SearchPropertyPage(string title, string partners, string categoryId, string statusId, int page)
        {
            var start = 10 * (page - 1);
            IEnumerable<Property> properties = _db.Properties
                     .Include(p => p.Member)
                     .Include(p => p.Category)
                     .Include(p => p.Status)
                     .Include(p => p.Images)
                     .Include(p => p.City)
                     .ThenInclude(ci => ci.Country)
                     .ThenInclude(co => co.Region)
                     .ToList();
            if (!title.Equals(".all"))
            {
                properties = properties.Where(p => p.Title.ToLower().Contains(title.ToLower())).ToList();
            }
            if (!partners.Equals(".all"))
            {
                properties = properties.Where(p => p.Member.FullName.ToLower().Contains(partners.ToLower()) || p.Member.Username.Equals(partners)).ToList();
            }
            if (!categoryId.Equals("all"))
            {
                properties = properties.Where(p => p.CategoryId == int.Parse(categoryId)).ToList();
            }
            if (!statusId.Equals("all"))
            {
                properties = properties.Where(p => p.StatusId == int.Parse(statusId)).ToList();
            }
            return properties.Skip(start).Take(10).ToList();
        }

        public int SearchProperty(string title, string partners, string categoryId, string statusId)
        {
            IEnumerable<Property> properties = _db.Properties
                     .Include(p => p.Member)
                     .Include(p => p.Category)
                     .Include(p => p.Status)
                     .Include(p => p.Images)
                     .Include(p => p.City)
                     .ThenInclude(ci => ci.Country)
                     .ThenInclude(co => co.Region)
                     .ToList();
            if (!title.Equals(".all"))
            {
                properties = properties.Where(p => p.Title.ToLower().Contains(title.ToLower())).ToList();
            }
            if (!partners.Equals(".all"))
            {
                properties = properties.Where(p => p.Member.FullName.ToLower().Contains(partners.ToLower()) || p.Member.Username.Equals(partners)).ToList();
            }
            if (!categoryId.Equals("all"))
            {
                properties = properties.Where(p => p.CategoryId == int.Parse(categoryId)).ToList();
            }
            if (!statusId.Equals("all"))
            {
                properties = properties.Where(p => p.StatusId == int.Parse(statusId)).ToList();
            }
            return properties.Count();
        }

        public List<Image> GetGallery(int propertyId)
        {
            return _db.Images.Where(i => i.PropertyId == propertyId).ToList();
        }

        public int CountProperty(int memberId)
        {
            return _db.Properties.Count(p => p.MemberId == memberId && p.StatusId == 1);
        }

        public int CountPropertyPending()
        {
            return _db.Properties.Count(p => p.Status.Name.Equals("Pending"));
        }

        public IEnumerable<Property> SearchPropertyPageByMember(int memberId, string title, string partners, string categoryId, string statusId, int page)
        {
            var start = 10 * (page - 1);
            IEnumerable<Property> properties = _db.Properties
                     .Include(p => p.Member)
                     .Include(p => p.Category)
                     .Include(p => p.Status)
                     .Include(p => p.Images)
                     .Include(p => p.City)
                     .ThenInclude(ci => ci.Country)
                     .ThenInclude(co => co.Region)
                     .Where(p => p.MemberId == memberId)
                     .ToList();
            if (!title.Equals(".all"))
            {
                properties = properties.Where(p => p.Title.ToLower().Contains(title.ToLower())).ToList();
            }
            if (!partners.Equals(".all"))
            {
                properties = properties.Where(p => p.Member.FullName.ToLower().Contains(partners.ToLower()) || p.Member.Username.Equals(partners)).ToList();
            }
            if (!categoryId.Equals("all"))
            {
                properties = properties.Where(p => p.CategoryId == int.Parse(categoryId)).ToList();
            }
            if (!statusId.Equals("all"))
            {
                properties = properties.Where(p => p.StatusId == int.Parse(statusId)).ToList();
            }
            return properties.Skip(start).Take(10).ToList();
        }

        public int SearchPropertyByMember(int memberId, string title, string partners, string categoryId, string statusId)
        {
            IEnumerable<Property> properties = _db.Properties
                                 .Include(p => p.Member)
                                 .Include(p => p.Category)
                                 .Include(p => p.Status)
                                 .Include(p => p.Images)
                                 .Include(p => p.City)
                                 .ThenInclude(ci => ci.Country)
                                 .ThenInclude(co => co.Region)
                                 .Where(p => p.MemberId == memberId)
                                 .ToList();
            if (!title.Equals(".all"))
            {
                properties = properties.Where(p => p.Title.ToLower().Contains(title.ToLower())).ToList();
            }
            if (!partners.Equals(".all"))
            {
                properties = properties.Where(p => p.Member.FullName.ToLower().Contains(partners.ToLower()) || p.Member.Username.Equals(partners)).ToList();
            }
            if (!categoryId.Equals("all"))
            {
                properties = properties.Where(p => p.CategoryId == int.Parse(categoryId)).ToList();
            }
            if (!statusId.Equals("all"))
            {
                properties = properties.Where(p => p.StatusId == int.Parse(statusId)).ToList();
            }
            return properties.Count();
        }
    }
}
