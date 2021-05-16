using Microsoft.EntityFrameworkCore;
using NETAPI_SEM3.Entities;
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
            var property = _db.Properties.Find(id);
            _db.Properties.Remove(property);
            return false;
        }

        public IEnumerable<Property> GetAllProperty()
        {
            return _db.Properties
             .Include(p => p.Member)
             .ThenInclude(m => m.Role)
             .Include(p => p.Category)
             .Include(p => p.City)
             .Include(p => p.Status)
             .Include(p => p.PropertyImages)
             .ToList();
        }

        public Property GetPropertyByid(int id)
        {
            return _db.Properties
              .Include(p => p.Member)
              .ThenInclude(m => m.Role)
              .Include(p => p.Category)
              .Include(p => p.City)
              .Include(p => p.Status)
              .Include(p => p.PropertyImages)
              .Where(p => p.PropertyId == id)
              .FirstOrDefault();
        }

        public Property UpdateProperty(Property property)
        {
            Debug.WriteLine(property.PropertyId);
            if (property != null)
            {
                _db.Properties.Add(property);
            }
            _db.SaveChanges();
            return null;
        }

        public Property AddNewProperty(Property property)
        {
            Debug.WriteLine(property.PropertyId);
            if (property != null)
            {
                _db.Properties.Add(property);
            }
            _db.SaveChanges();
            return null;
        }

    }
}
