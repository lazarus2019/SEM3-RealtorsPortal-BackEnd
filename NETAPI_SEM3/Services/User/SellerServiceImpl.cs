using NETAPI_SEM3.Entities;
using NETAPI_SEM3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETAPI_SEM3.Services.User
{
    public class SellerServiceImpl : SellerService
    {
        private DatabaseContext db;
        public SellerServiceImpl(DatabaseContext _db)
        {
            db = _db;
        }

        public List<Member> LoadAgent()
        {
            var result1 = db.Members.Where(m => m.RoleId.Equals("2"))
                .ToList();

            return result1;
        }

        public List<Member> LoadSearchSeller()
        {
            throw new NotImplementedException();
        }

        public List<Member> LoadSeller()
        {
            var result =  db.Members.Where( m => m.RoleId.Equals("3"))
                .ToList();

            return result;
        }

        // Load 1 Seller / Agent + Property By Id
        public NewMember SellerDetails(int sellerId)
        {
            return db.Members.Select( m => new NewMember
            {
                MemberId = m.MemberId ,
                FullName = m.FullName,
                RoleId = m.RoleId,
                Username = m.Username,
                Phone = m.Phone,
                Status = m.Status,
                Photo = m.Photo,
                CreateDate = m.CreateDate,

            }).SingleOrDefault(p => p.MemberId == sellerId);
        }
        public List<Property> LoadPropertyId(int propertyId)
        {
            return db.Properties.Where(k => k.MemberId == propertyId).ToList();
        }


    }
}
