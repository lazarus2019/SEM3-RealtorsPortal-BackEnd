using Microsoft.EntityFrameworkCore;
using NETAPI_SEM3.Entities;
using NETAPI_SEM3.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETAPI_SEM3.Services
{
    public class MemberServiceImpl : MemberService
    {
        private readonly DatabaseContext _db;

        public MemberServiceImpl(DatabaseContext db)
        {
            this._db = db;
        }

        public IEnumerable<Member> GetAllMember()
        {
            //return _db.Members.Join(_db.Roles, m => m.RoleId, r => r.RoleId, (m, r) => m).ToList();
            return _db.Members.Include(m => m.Role).ToList();
        }
    }
}
