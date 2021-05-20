using NETAPI_SEM3.Entities;
using NETAPI_SEM3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETAPI_SEM3.Services.User
{
    public interface ListingService
    {
        public List<NewProperty> GetAllListing() ;
        public List<Category> getCategory() ;
        public List<Region> getRegion() ;
        public NewProperty PropertyDetail(int propertyId); 
        //public List<Property> search
        //    (string? keyword , string? location , string region , string type , double area , int bed , int room , double price );
    }
}
