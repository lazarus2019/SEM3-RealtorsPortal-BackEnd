using Microsoft.AspNetCore.Identity;
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
        public List<NewProperty> GetAllListing( int page) ;
        public List<NewProperty> GetPopularPost( int memberId) ;
        public int GetListingCount() ;
        public Setting GetSetting();
        //public IdentityRole GetRole(string RoleId) ;
        public List<IdentityRole> GetAllRole() ;
        public List<Category> getCategory() ;
        public List<Region> getRegion() ;
        public List<NewCity> getCity(int countryId) ;
        public List<NewCity> getAllCity() ;
        public NewProperty PropertyDetail(int propertyId);
        public List<NewProperty> SearchProperty(string keyword, int categoryId, int countryId , int page);
        public int SearchPropertyCount(  string keyword, int categoryId, int countryId);
        public List<NewProperty> SearchPropertyListing(string keyword, int categoryId, int countryId ,int city , string type , double area , int bed, int room, double price, int page);
        public int SearchPropertyListingCount( string keyword, int categoryId, int countryId ,int city , string type , double area , int bed, int room, double price);


    }
}
