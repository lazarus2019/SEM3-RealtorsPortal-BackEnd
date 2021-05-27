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
            var result1 = db.Members.Where(m => m.RoleId == 2)
               .ToList();

            return result1;
        }

        public List<Setting> loadSetting()
        {
            var setting = db.Settings.Where(p => p.SettingId == 1).ToList();

            return setting;
        }

        
    }
}
