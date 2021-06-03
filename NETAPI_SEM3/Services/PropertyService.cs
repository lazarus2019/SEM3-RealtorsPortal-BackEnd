using NETAPI_SEM3.Models;
using NETAPI_SEM3.ViewModel;
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
        public IEnumerable<Property> SearchPropertyPage(string title, string partners, string categoryId, string statusId, int page);
        public int SearchProperty(string title, string partners, string categoryId, string statusId);
        public IEnumerable<Property> GetAllPropertyPageByMember(int memberId, int page);
        public int GetAllPropertyByMember(int memberId);
        public IEnumerable<Property> SearchPropertyPageByMember(int memberId, string title, string partners, string categoryId, string statusId, int page);
        public int SearchPropertyByMember(int memberId, string title, string partners, string categoryId, string statusId);
        public PropertyViewModel GetPropertyByid(int id);
        public int CountProperty(int memberId);
        public int CountPropertyPending();
        public bool DeleteProperty(int id);
        public bool UpdateProperty(Property property);
        public bool UpdateStatus(int id, int statusId);
        public int CreateProperty(Property property);
        public List<Image> GetGallery(int propertyId);

    }
}
