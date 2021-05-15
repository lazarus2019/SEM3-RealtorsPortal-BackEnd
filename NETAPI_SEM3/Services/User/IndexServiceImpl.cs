using NETAPI_SEM3.Entities;
using NETAPI_SEM3.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace NETAPI_SEM3.Services.User
{
    public class IndexServiceImpl : IndexService
    {
        private DatabaseContext db;
        public IndexServiceImpl(DatabaseContext _db)
        {
            db = _db;
        }

        public List<PopularLocations> LoadPopularLocations()
        {
            return db.Cities.Select(
                c => new PopularLocations
                {
                    CityId = c.CityId,
                    Name = c.Name,
                    NumberProperties = c.Properties.Count()
                }).OrderByDescending( c=> c.NumberProperties).Take(4).ToList();
        }

        public List<Property> LoadTopProperty()
        {
            var results =  db.Properties
                .OrderByDescending(p => p.UploadDate)
                .OrderBy(p => p.Price)
                .OrderByDescending(p => p.Area)
                .Take(6).ToList();

            return results;
            /*
                */
        }
    }
}
