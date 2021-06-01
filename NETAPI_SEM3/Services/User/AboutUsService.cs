using NETAPI_SEM3.Entities;
using NETAPI_SEM3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETAPI_SEM3.Services.User
{
    public interface AboutUsService
    {
        public List<Member> loadAgentAU();
        public List<Setting> loadSetting();
        public int RentCount();
        public int SaleCount();
        public List<Faq> getAllFAQ();

    }
}
