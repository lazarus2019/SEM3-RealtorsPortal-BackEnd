using NETAPI_SEM3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETAPI_SEM3.Services
{
    public interface PropertyService
    {
        public IEnumerable<Property> GetAllProperty();
        public IEnumerable<Property> SearchProperty(string title, string roleId, string categoryId, string statusId);
        public Property GetPropertyByid(int id);
        public bool DeleteProperty(int id);
        public bool UpdateProperty(Property property);
        public bool UpdateStatus(int id, int statusId);
        public int CreateProperty(Property property);
        public List<Image> getGallery(int propertyId);

    }
}
