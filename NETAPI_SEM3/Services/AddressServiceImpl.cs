using Microsoft.EntityFrameworkCore;
using NETAPI_SEM3.Models;
using NETAPI_SEM3.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Diagnostics;

namespace NETAPI_SEM3.Services
{
    public class AddressServiceImpl : AddressService
    {
        private readonly DatabaseContext _db;


        public AddressServiceImpl(DatabaseContext db

            )
        {
            this._db = db;

        }

        public IEnumerable<Region> GetAllRegion()
        {
            return _db.Regions.ToList();
        }

        public IEnumerable<Country> GetAllCountry()
        {
            return _db.Countries.ToList();
        }

        public IEnumerable<City> GetAllCity()
        {
            return _db.Cities.ToList();
        }
    }
}
