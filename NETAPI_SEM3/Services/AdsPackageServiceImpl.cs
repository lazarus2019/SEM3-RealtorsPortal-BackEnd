using NETAPI_SEM3.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETAPI_SEM3.Services
{
    public class AdsPackageServiceImpl : AdsPackageService
    {

        private readonly DatabaseContext _db;

        public AdsPackageServiceImpl(DatabaseContext db)
        {
            this._db = db;
        }
        public IEnumerable<AdPackage> GetAllAdsPackage()
        {
            return _db.AdPackages.ToList();
        }
    }
}
