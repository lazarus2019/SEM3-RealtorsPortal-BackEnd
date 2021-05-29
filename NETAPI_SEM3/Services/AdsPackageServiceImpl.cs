using NETAPI_SEM3.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public AdPackage GetAdPackageByid(int id)
        {
            try
            {
                return _db.AdPackages.Find(id);

            }
            catch
            {
                return null;
            }

        }

        public bool DeleteAdsPackage(int id)
        {
            try
            {
                var adsPackage = _db.AdPackages.Find(id);
                adsPackage.IsDelete = true;
                _db.AdPackages.Update(adsPackage);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<AdPackage> GetAllAdsPackage()
        {
            return _db.AdPackages.Where(a => a.IsDelete == false).ToList();
        }

        public bool UpdateStatus(int id, bool status)
        {
            try
            {
                var adsPackage = _db.AdPackages.Find(id);
                adsPackage.StatusBuy = status;
                _db.AdPackages.Update(adsPackage);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<AdPackage> GetAllAdsPackageForSalePage()
        {
            return _db.AdPackages.Where(a => a.IsDelete == false && a.StatusBuy == true).ToList();
        }

        public IEnumerable<AdPackage> SearchAdsPackage(string status, string name, string price)
        {
            IEnumerable<AdPackage> adPackages = null;
            if (status.Equals("true"))
            {
                adPackages = _db.AdPackages.Where(a => a.IsDelete == false && a.StatusBuy == bool.Parse(status)).ToList();
            } else
            {
                adPackages = _db.AdPackages.Where(a => a.IsDelete == false).ToList();
            }
            if (!name.Equals(".all"))
            {
                adPackages = adPackages.Where(a => a.NameAdPackage.ToLower().Contains(name.ToLower())).ToList();
            }
            if (!price.Equals(".all"))
            {
                adPackages = adPackages.Where(a => a.Price <= Convert.ToDecimal(price)).ToList();
            }
            return adPackages;
        }

        public double GetMaxPrice()
        {
            return (double)_db.AdPackages.Where(a => a.IsDelete == false).Select(a => a.Price).Max();
        }

        public bool UpdateAdsPackage(AdPackage adPackage)
        {
            try
            {
                _db.AdPackages.Update(adPackage);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public AdPackage CreateAdsPackage(AdPackage adPackage)
        {
            try
            {
                if (adPackage != null)
                {
                    _db.AdPackages.Add(adPackage);
                    _db.SaveChanges();
                }
                return adPackage;
            }
            catch
            {
                return null;
            }
        }

        public MemberPackageDetail CreateMemberPackageDetail(MemberPackageDetail memberPackageDetail)
        {
            try
            {
                if (memberPackageDetail != null)
                {
                    _db.MemberPackageDetails.Add(memberPackageDetail);
                    _db.SaveChanges();
                }
                return memberPackageDetail;
            }
            catch
            {
                return null;
            }
        }

        public int GetPeriodDay(int id)
        {
            return _db.AdPackages.FirstOrDefault(a => a.PackageId == id).Period ?? default(int);
        }

        public int GetPostLimit(int packageId)
        {
            return _db.AdPackages.FirstOrDefault(a => a.PackageId == packageId).PostNumber ?? default(int);
        }

        public int GetPackageIdByMemberId(int memberId)
        {
            return _db.MemberPackageDetails.SingleOrDefault(pd => pd.MemberId == memberId).PackageId;
        }

        public bool CheckExpiryDate(int memberId)
        {
            var expiryDate = _db.MemberPackageDetails.SingleOrDefault(pd => pd.MemberId == memberId).ExpiryDate ?? default(DateTime);
            var today = DateTime.Now;
            var result = true;

            if (today.CompareTo(expiryDate) > 0)
            {
                result = false;
            }
            else if (today.CompareTo(expiryDate) <= 0)
            {
                result = true;
            }
            return result;
        }
    }
}
