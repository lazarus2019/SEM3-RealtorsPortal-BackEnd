using NETAPI_SEM3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETAPI_SEM3.Services
{
    public interface PropertyService
    {
        public IEnumerable<Property> GetAllPropertyPage(int page);
        public int GetAllProperty();
        public IEnumerable<Property> GetAllPropertyPageByMember(int memberId, int page);
        public int GetAllPropertyByMember(int memberId);
        public IEnumerable<Property> SearchPropertyPage(string title, string roleId, string categoryId, string statusId, int page);
        public int SearchProperty(string title, string roleId, string categoryId, string statusId);
        public Property GetPropertyByid(int id);
        public int CountProperty(int memberId);
        public bool DeleteProperty(int id);
        public bool UpdateProperty(Property property);
        public bool UpdateStatus(int id, int statusId);
        public int CreateProperty(Property property);
        public List<Image> GetGallery(int propertyId);

    }
}
