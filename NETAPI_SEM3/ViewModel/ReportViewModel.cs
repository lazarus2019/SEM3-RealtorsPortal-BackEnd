using NETAPI_SEM3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETAPI_SEM3.ViewModel
{
    public class ReportViewModel
    {
        public int MemberCount { get; set; }
        public int MemberToday { get; set; }
        
        public int InvoiceCount { get; set; }
        public int InvoiceToday { get; set; }
        public int AdPackageCount { get; set; }
    
        public int CategoryCount { get; set; }

        
    }
}
