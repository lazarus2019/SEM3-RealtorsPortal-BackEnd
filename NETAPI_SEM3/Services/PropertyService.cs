using NETAPI_SEM3.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETAPI_SEM3.Services
{
    public interface PropertyService
    {
        public IEnumerable<Property> GetAllProperty();
        public Property GetPropertyByid(int id);
        public bool UpdateStatus(int id, Property property);
    }
}
