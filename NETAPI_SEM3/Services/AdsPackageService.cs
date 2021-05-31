using NETAPI_SEM3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETAPI_SEM3.Services
{
    public interface AdsPackageService
    {
        public int GetAllAdsPackage();
        public IEnumerable<AdPackage> GetAllAdsPackagePage(int page);
        public int GetAllAdsPackageForSalePage();
        public IEnumerable<AdPackage> GetAllAdsPackageForSalePagePerPage(int page);
        public double GetMaxPrice();
        public int GetPeriodDay(int id);
        public int GetPostLimit(int packageId);
        public int GetPackageIdByMemberId(int memberId);
        public bool CheckExpiryDate(int memberId);
        public bool CheckPackage(int memberId);
        public AdPackage CreateAdsPackage(AdPackage adPackage);
        public MemberPackageDetail CreateMemberPackageDetail(MemberPackageDetail memberPackageDetail);
        public bool DeleteAdsPackage(int id);
        public bool UpdateStatus(int id, bool status);
        public bool UpdateAdsPackage(AdPackage adPackage);
        public AdPackage GetAdPackageByid(int id);
        public int SearchAdsPackage(string status, string name, string price);
        public IEnumerable<AdPackage> SearchAdsPackagePage(string status, string name, string price, int page);
    }
}
