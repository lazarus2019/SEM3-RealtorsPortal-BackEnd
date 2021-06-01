using NETAPI_SEM3.Entities;
using NETAPI_SEM3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETAPI_SEM3.Services.User
{
    public class SettingServiceImpl : SettingService
    {
        DatabaseContext db;
        public SettingServiceImpl(DatabaseContext _db)
        {
            db = _db;
        }

        public List<Setting> getAllSetting()
        {
            return db.Settings.Where(p => p.SettingId == 1).ToList();
        }
    }
}
