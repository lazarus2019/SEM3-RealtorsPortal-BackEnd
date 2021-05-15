using Microsoft.EntityFrameworkCore;
using NETAPI_SEM3.Entities;
using System;
using System.Collections.Generic;
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

        public void AddEntity(object model)
        {
            _db.Add(model);
        }

        public IEnumerable<Property> GetAllProperty()
        {
            try
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
            catch
            {
                return null;
            }
        }

        public Property GetPropertyByid(int id)
        {
            try
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
            catch
            {
                return null;
            }
        }

        public bool UpdateStatus(int id, Property property)
        {
            try
            {
                var propertycurrent = _db.Properties.SingleOrDefault(p => p.PropertyId == id);
                if(propertycurrent != null)
                {
                    propertycurrent.Status.Name = property.Status.Name;

                }
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
