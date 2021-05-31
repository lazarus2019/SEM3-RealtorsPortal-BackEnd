using NETAPI_SEM3.Models;
using NETAPI_SEM3.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETAPI_SEM3.Services
{
    public interface AddressService
    {

        public IEnumerable<Region> GetAllRegion();
        public IEnumerable<Country> GetAllCountry();
        public IEnumerable<City> GetAllCity();

    }
}
