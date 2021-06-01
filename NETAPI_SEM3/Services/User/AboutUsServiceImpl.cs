using NETAPI_SEM3.Entities;
using NETAPI_SEM3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETAPI_SEM3.Services.User
{
    public class AboutUsServiceImpl : AboutUsService
    {
        private DatabaseContext db;
        public AboutUsServiceImpl (DatabaseContext _db)
        {
            db = _db;
        }

        public List<Member> loadAgentAU()
        {
            var result1 = db.Members.Where(m => m.RoleId.Equals("2")).Take(4)
               .ToList();

            return result1;
        }

        public int RentCount()
        {
            return db.Properties.Where(p => p.Type.Equals("Rent")).ToList().Count();
        }
        public int SaleCount()
        {
            return db.Properties.Where(p => p.Type.Equals("Sale")).ToList().Count();
        }
        public List<Setting> loadSetting()
        {
            var setting = db.Settings.Where(p => p.SettingId == 1).ToList();

            return setting;
        }

        public List<Faq> getAllFAQ()
        {
            return db.Faqs.ToList();
        }

    }
}
