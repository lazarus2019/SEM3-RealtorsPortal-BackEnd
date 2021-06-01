using NETAPI_SEM3.Models;
using NETAPI_SEM3.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETAPI_SEM3.Services
{
    public class ReportServiceImpl : ReportService
    {

        private DatabaseContext db;

        public ReportServiceImpl(DatabaseContext db)
        {
            this.db = db;
        }

        public List<InvoiceViewModel> getPayment()
        {
            return db.Invoices.Select(i => new InvoiceViewModel
            {
                InvoiceId = i.InvoiceId,
                Created = i.Created,
                MemberId = i.MemberId,
                Name = i.Name,
                PackageId = i.PackageId,
                PaymentCard = i.PaymentCard,
                PaymentCode = i.PaymentCode,
                PaymentMethod = i.PaymentMethod,
                Total = i.Total,
                AdsPackage = new AdspackageViewModel
                {
                    NameAdPackage = i.Package.NameAdPackage,
                    Description = i.Package.Description,
                    isDelete = i.Package.IsDelete,
                    PackageId = i.PackageId,
                    Period = i.Package.Period,
                    PostNumber = i.Package.PostNumber,
                    Price = i.Package.Price,
                    StatusBuy = i.Package.StatusBuy
                },
                Member = new MemberViewModel
                {
                    CreateDate = i.Member.CreateDate,
                    Email = i.Member.Email,
                    FullName = i.Member.FullName,
                    MemberId = i.MemberId,
                    Photo = i.Member.Photo,
                    Username = i.Member.Username,
                    Status = i.Member.Status,
                    RoleId = i.Member.RoleId,
                    RoleName = db.Roles.SingleOrDefault(r => r.Id == i.Member.RoleId).Name
                }
            }).OrderByDescending(i => i.Created).ToList();

        }

        public ReportViewModel getReport()
        {
            return new ReportViewModel
            {
                MemberCount = db.Members.Count(),
                MemberToday = db.Members.Where(m => m.CreateDate.Day == DateTime.Now.Day).Count(),
                InvoiceCount = db.Invoices.Count(),
                InvoiceToday = db.Invoices.Where(i => i.Created.Day == DateTime.Now.Day).Count(),
                AdPackageCount = db.AdPackages.Count(),
                CategoryCount = db.Categories.Count()
            };
        }

        public List<InvoiceViewModel> searchPaymentByDate(DateTime fromDate, DateTime toDate)
        {
            
            var invoices = db.Invoices.ToList();

            invoices = invoices.Where(i => i.Created.Date >= fromDate.Date && i.Created.Date <= toDate.Date).ToList();

               return invoices.Select(i => new InvoiceViewModel
                {
                    InvoiceId = i.InvoiceId,
                    Created = i.Created,
                    MemberId = i.MemberId,
                    Name = i.Name,
                    PackageId = i.PackageId,
                    PaymentCard = i.PaymentCard,
                    PaymentCode = i.PaymentCode,
                    PaymentMethod = i.PaymentMethod,
                    Total = i.Total,
                    AdsPackage = new AdspackageViewModel
                    {
                        NameAdPackage = i.Package.NameAdPackage,
                        Description = i.Package.Description,
                        isDelete = i.Package.IsDelete,
                        PackageId = i.PackageId,
                        Period = i.Package.Period,
                        PostNumber = i.Package.PostNumber,
                        Price = i.Package.Price,
                        StatusBuy = i.Package.StatusBuy
                    },
                    Member = new MemberViewModel
                    {
                        CreateDate = i.Member.CreateDate,
                        Email = i.Member.Email,
                        FullName = i.Member.FullName,
                        MemberId = i.MemberId,
                        Photo = i.Member.Photo,
                        Username = i.Member.Username,
                        Status = i.Member.Status,
                        RoleId = i.Member.RoleId,
                        RoleName = db.Roles.SingleOrDefault(r => r.Id == i.Member.RoleId).Name
                    }
                }).OrderByDescending(i => i.Created).ToList();
        }

        public List<InvoiceViewModel> searchPaymentByDuration(string duration)
        {
            var invoices = db.Invoices.ToList();
            var results = new List<Invoice>(); 
            var date = DateTime.Now;
            if (duration == "today")
            {
                invoices.Where(i => i.Created.Day == date.Day && i.Created.Month == date.Month)
                        .ToList()
                        .ForEach(i =>
                        {
                            results.Add(i); 
                            Debug.WriteLine(" Day : " + i.Created.Day);
                            Debug.WriteLine(" Created : " + i.Created.ToString());
                        });
            }
            else if (duration == "yesterday")
            {
                invoices.Where(i => (date - i.Created).TotalDays <= 1).ToList().ForEach(i =>
                {
                    results.Add(i);
                    Debug.WriteLine(" Day : " + i.Created.Day);
                    Debug.WriteLine(" Created : " + i.Created.ToString());
                });
            }
            else if (duration == "week")
            {
                invoices.Where(i => (date - i.Created).TotalDays > 0 && (date - i.Created).TotalDays < 7).ToList().ForEach(i =>
                        {
                            results.Add(i); 
                            Debug.WriteLine(" Day : " + i.Created.Day);
                            Debug.WriteLine(" Created : " + i.Created.ToString());
                        });
            }
            else if (duration == "month")
            {
                invoices.Where(i => i.Created.Day == date.Day)
                            .Where(i => i.Created.Month >= (date.Month - 1) && i.Created.Month <= date.Month)
                            .Where(i => i.Created.Year == date.Year).ToList().ForEach(i =>
                        {
                            results.Add(i); 
                            Debug.WriteLine(" Day : " + i.Created.Day);
                            Debug.WriteLine(" Created : " + i.Created.ToString());
                        });
            };

            return results
                .Select(i => new InvoiceViewModel
                {
                    InvoiceId = i.InvoiceId,
                    Created = i.Created,
                    MemberId = i.MemberId,
                    Name = i.Name,
                    PackageId = i.PackageId,
                    PaymentCard = i.PaymentCard,
                    PaymentCode = i.PaymentCode,
                    PaymentMethod = i.PaymentMethod,
                    Total = i.Total,
                    AdsPackage = new AdspackageViewModel
                    {
                        NameAdPackage = i.Package.NameAdPackage,
                        Description = i.Package.Description,
                        isDelete = i.Package.IsDelete,
                        PackageId = i.PackageId,
                        Period = i.Package.Period,
                        PostNumber = i.Package.PostNumber,
                        Price = i.Package.Price,
                        StatusBuy = i.Package.StatusBuy
                    },
                    Member = new MemberViewModel
                    {
                        CreateDate = i.Member.CreateDate,
                        Email = i.Member.Email,
                        FullName = i.Member.FullName,
                        MemberId = i.MemberId,
                        Photo = i.Member.Photo,
                        Username = i.Member.Username,
                        Status = i.Member.Status,
                        RoleId = i.Member.RoleId,
                        RoleName = db.Roles.SingleOrDefault(r => r.Id == i.Member.RoleId).Name
                    }
                }).OrderByDescending(i => i.Created).ToList();
        }

        public ReportViewModel searchReportByDate(DateTime fromDate, DateTime toDate)
        {
            return new ReportViewModel
            {
                MemberCount = db.Members
                    .Where(i => i.CreateDate.Date >= fromDate.Date && i.CreateDate.Date <= toDate.Date).Count(),
                MemberToday = db.Members.Where(m => m.CreateDate.Day == DateTime.Now.Day).Count(),
                InvoiceCount = db.Invoices
                    .Where(i => i.Created.Date >= fromDate.Date && i.Created.Date <= toDate.Date).Count(), 
                InvoiceToday = db.Invoices.Where(i => i.Created.Day == DateTime.Now.Day).Count(),
                AdPackageCount = db.AdPackages.Count(),
                CategoryCount = db.Categories.Count(),

            };
        }

        public ReportViewModel searchReportByDuration(string duration)
        {
            var date = DateTime.Now; 
            var report = new ReportViewModel
            {
                AdPackageCount = db.AdPackages.Count(),
                CategoryCount = db.Categories.Count(),
                InvoiceToday = db.Invoices.Where(i => i.Created.Day == date.Day).Count(),
                MemberToday = db.Members.Where(m => m.CreateDate.Day == date.Day).Count()
            };
            if( duration == "today")
            {
                report.MemberCount = db.Members
                           .Where(i => i.CreateDate.Day == date.Day)
                           .Where(i => i.CreateDate.Month == date.Month)
                           .Where(i => i.CreateDate.Year == date.Year).Count();
                report.InvoiceCount = db.Invoices
                    .Where(i => i.Created.Day == date.Day)
                    .Where(i => i.Created.Month == date.Month)
                    .Where(i => i.Created.Year == date.Year).Count();

            }
            else if( duration == "yesterday")
            {
                var yesterday = DateTime.Today;
                yesterday = yesterday.AddDays(-1); 
                report.MemberCount = db.Members
                    .Where(n => n.CreateDate.Date >= yesterday.Date && n.CreateDate.Date <= date)
                    .Count(); 
                report.InvoiceCount = db.Invoices.Where(n => n.Created.Date >= yesterday.Date && n.Created.Date <= date).ToList().Count();
            }
            else if(duration == "week")
            {
                var week = DateTime.Today;
                week = week.AddDays(-7);
                report.MemberCount = db.Members.Where(n => n.CreateDate.Date >= week.Date && n.CreateDate.Date <= date).Count();
                report.InvoiceCount = db.Invoices.Where(n => n.Created.Date >= week.Date && n.Created.Date <= date).ToList().Count();
            }
            else if ( duration == "month")
            {
                var month = DateTime.Today;
                month = month.AddMonths(-1);                
                report.MemberCount = db.Members.Where(n => n.CreateDate.Date >= month.Date && n.CreateDate.Date <= date).Count();
                report.InvoiceCount = db.Invoices.Where(n => n.Created.Date >= month.Date && n.Created.Date <= date).ToList().Count();
            }

            return report;
        }

    }
}
