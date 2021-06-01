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
        private readonly DatabaseContext db;
        private Setting setting; 

        public PropertyServiceImpl(DatabaseContext db)
        {
            this.db = db;
            setting = db.Settings.First(); 
        }

        public bool DeleteProperty(int id)
        {
            try
            {
                var property = db.Properties.Find(id);
                db.Properties.Remove(property);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<Property> GetAllProperty(int page)
        {
            return db.Properties.OrderBy(p => p.StatusId == 4)
             .Include(p => p.Member)
             .Include(p => p.Category)
             //.Include(p => p.City)
             //.ThenInclude(ci => ci.Country)
             //.ThenInclude(co => co.Region)
             .Include(p => p.Status)
             .Skip((page-1)*setting.NumProperty)
             .Take(setting.NumProperty)
             .ToList();
        }

        public Property GetPropertyByid(int id)
        {
            try
            {
                return db.Properties
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
                //var p = db.Properties.Find(property.PropertyId);
                //p = property;
                db.Properties.Update(property);
                db.SaveChanges();
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
                    db.Properties.Add(property);
                    db.SaveChanges();
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
                var property = db.Properties.Find(id);
                property.StatusId = statusId;
                db.Properties.Update(property);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<Property> SearchProperty(int page , string title, string partners, string categoryId, string statusId)
        {
            IEnumerable<Property> properties = db.Properties
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
            return properties.Skip((page - 1) * setting.NumProperty).Take(setting.NumProperty).ToList();
        }

        public List<Image> GetGallery(int propertyId)
        {
            return db.Images.Where(i => i.PropertyId == propertyId).ToList();
        }

        public int CountProperty(int memberId)
        {
            return db.Properties.Count(p => p.MemberId == memberId && p.StatusId == 1);
        }

        public int PropertyCount()
        {
            return db.Properties.Where( p=>p.StatusId == 1 ).Count(); 
        }

        public int SearchPropertyCount(string title, string roleId, string categoryId, string statusId)
        {
            throw new NotImplementedException();
        }
    }
}
