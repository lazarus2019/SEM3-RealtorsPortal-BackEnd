using NETAPI_SEM3.Models;
using NETAPI_SEM3.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETAPI_SEM3.Services
{
    public class InvoiceServiceImpl : InvoiceService
    {
        private readonly DatabaseContext db;


        public InvoiceServiceImpl(DatabaseContext _db)
        {
            this.db = _db;
            
        }

        public bool CheckPackage(int memberId)
        {
            try
            {

                var packageDetail = db.MemberPackageDetails.SingleOrDefault(pd => pd.MemberId == memberId);
                db.Remove(packageDetail);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }

        public Invoice CreateInvoice(Invoice invoice)
        {
            try
            {
                if (invoice != null)
                {
                    db.Invoices.Add(invoice);
                    db.SaveChanges();
                }
                return invoice;
            }
            catch
            {
                return null;
            }
        }

        public List<InvoiceViewModel> getAllInvoice(int page)
        {
            var result = db.Invoices.ToList();
            var skip = (page - 1) * 10;
            if ( page == 1 ) {
                result = result.Take(10).ToList();
            }
            else
            {
                result = result.Skip(skip).Take(10).ToList(); 
            }

            return result.Select(i => new InvoiceViewModel {
                Created = i.Created , 
                InvoiceId = i.InvoiceId , 
                MemberId = i.MemberId , 
                Name = i.Name , 
                PackageId = i.PackageId , 
                PaymentCard = i.PaymentCard ,
                PaymentCode = i.PaymentCode , 
                PaymentMethod = i.PaymentMethod , 
                Total = i.Total , 
                AdsPackage = new AdspackageViewModel
                {
                    PackageId = i.Package.PackageId , 
                    Description = i.Package.Description , 
                    isDelete = i.Package.IsDelete , 
                    NameAdPackage = i.Package.NameAdPackage , 
                    Period = i.Package.Period ,
                    PostNumber  = i.Package.PostNumber , 
                    Price = i.Package.Price , 
                    StatusBuy  = i.Package.StatusBuy 
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
            }).ToList();
        }

        public List<InvoiceViewModel> searchInvoice(string keyword, int page)
        {
            var result = db.Invoices.ToList();
            var skip = (page - 1) * 10;
            if (keyword != "all")
            {
                result = result.Where(i => i.Name.ToLower().Contains(keyword.Trim().ToLower()) ||
                                            i.Member.FullName.ToLower().Contains(keyword.Trim().ToLower())).ToList();
            }

            if (page == 1)
            {
                result = result.Take(10).ToList();
            }
            else
            {
                result = result.Skip(skip).Take(10).ToList();
            }

            return result.Select(i => new InvoiceViewModel
            {
                Created = i.Created,
                InvoiceId = i.InvoiceId,
                MemberId = i.MemberId,
                Name = i.Name,
                PackageId = i.PackageId,
                PaymentCard = i.PaymentCard,
                PaymentCode = i.PaymentCode,
                PaymentMethod = i.PaymentMethod,
                Total = i.Total,
                AdsPackage = new AdspackageViewModel
                {
                    PackageId = i.Package.PackageId,
                    Description = i.Package.Description,
                    isDelete = i.Package.IsDelete,
                    NameAdPackage = i.Package.NameAdPackage,
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
            }).ToList();
        }
        public int getAllInvoiceCount()
        {
            return db.Invoices.Count(); 
        }

        public int searchInvoiceCount(string keyword)
        {
            var result = db.Invoices.ToList();
            if (keyword != "all")
            {
                result = result.Where(i => i.Name.ToLower().Contains(keyword.Trim().ToLower()) ||
                                            i.Member.FullName.ToLower().Contains(keyword.Trim().ToLower())).ToList();
            }
            return result.Count(); 
        }
    }
}
