using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETAPI_SEM3.Entities
{
    public class Report
    {
        public int MemberCount { get; set; } 
        public int MemberToday { get; set; } 
        public int PaymentCount { get; set; }
        public int PaymentToday { get; set; }
        public int AdPackageCount { get; set; }
        public int AdPackageToday { get; set; }
        public int CategoryCount { get; set; }

    }
}
