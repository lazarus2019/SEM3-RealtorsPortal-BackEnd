using NETAPI_SEM3.Entities;
using NETAPI_SEM3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETAPI_SEM3.Services.Admin
{
    public class ReportServiceImpl : ReportService
    {
        private DatabaseContext db;
        public ReportServiceImpl(DatabaseContext _db)
        {
            db = _db;
        }
        public Report LoadReport()
        {
            return new Report {
                MemberCount = db.Members.Count() ,
                PaymentCount = db.Invoices.Count() ,
                AdPackageCount = db.AdPackages.Count() , 
                CategoryCount = db.Categories.Count() 
            };
        }
    }
}
