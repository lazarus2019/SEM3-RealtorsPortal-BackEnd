using NETAPI_SEM3.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETAPI_SEM3.Services
{
    public interface AdsPackageService
    {
        public IEnumerable<AdPackage> GetAllAdsPackage();
    }
}
