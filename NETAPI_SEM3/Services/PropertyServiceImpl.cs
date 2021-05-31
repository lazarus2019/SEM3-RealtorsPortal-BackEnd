using Microsoft.EntityFrameworkCore;
using NETAPI_SEM3.Models;
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
             //.Include(p => p.Images.Any() && p.Images.Where(i => i.PropertyId == p.PropertyId).First())
             //.Include(p => p.City)
             //.ThenInclude(ci => ci.Country)
             //.ThenInclude(co => co.Region)
             .ToList();
            listProperty = listProperty.Skip(start).Take(10).ToList();
            return listProperty;

        }

        public int GetAllProperty()
        {
            return _db.Properties
             .Include(p => p.Member)
             .Include(p => p.Category)
             //.Include(p => p.City)
             //.ThenInclude(ci => ci.Country)
             //.ThenInclude(co => co.Region)
             .Include(p => p.Status)
             .Count();
        }
        public IEnumerable<Property> GetAllPropertyPageByMember(int memberId, int page)
        {
            var start = 10 * (page - 1);
            var listProperty = _db.Properties
             .Include(p => p.Member)
             .Include(p => p.Category)
             .Include(p => p.Status)
             //.Include(p => p.Images.Any() && p.Images.Where(i => i.PropertyId == p.PropertyId).First())
             //.Include(p => p.City)
             //.ThenInclude(ci => ci.Country)
             //.ThenInclude(co => co.Region)
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
             //.Include(p => p.City)
             //.ThenInclude(ci => ci.Country)
             //.ThenInclude(co => co.Region)
             .Include(p => p.Status)
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
                //.Include(p => p.City)
                //.ThenInclude(ci => ci.Country)
                //.ThenInclude(co => co.Region)
                .FirstOrDefault(p => p.PropertyId == id);
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
                //var p = _db.Properties.Find(property.PropertyId);
                //p = property;
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
                     //.Include(p => p.City)
                     //.ThenInclude(ci => ci.Country)
                     //.ThenInclude(co => co.Region)
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
                     //.Include(p => p.City)
                     //.ThenInclude(ci => ci.Country)
                     //.ThenInclude(co => co.Region)
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
    }
}
