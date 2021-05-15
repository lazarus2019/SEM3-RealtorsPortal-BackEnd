using NETAPI_SEM3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETAPI_SEM3.Services.User
{
    public class ListingServiceImpl : ListingService
    {
        private DatabaseContext db;
        public ListingServiceImpl(DatabaseContext _db)
        {
            db = _db;
        }
        public List<Property> getAll()
        {
            return db.Properties.ToList();
        }

        public List<Category> getCategory()
        {
            return db.Categories.ToList(); 
        }

        public List<Region> getRegion()
        {
            return db.Regions.ToList();
        }

        //public List<Property> search(string keyword, string location, string region, string type, double area, int bed, int room, double price)
        //{

        //}
    }
}
