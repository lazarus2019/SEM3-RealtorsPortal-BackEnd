using Microsoft.EntityFrameworkCore;
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
    public class MemberServiceImpl : MemberService
    {
        private readonly DatabaseContext _db;

        public MemberServiceImpl(DatabaseContext db)
        {
            this._db = db;
        }

        public IEnumerable<Member> GetAllMember()
        {
            return _db.Members.Where(m => m.RoleId != "1").ToList();
        }

        public IEnumerable<Member> SearchMember(string fullName, string roleId, string status)
        {
            try
            {

                IEnumerable<Member> members = _db.Members.Where(m => m.RoleId != "1").ToList();
                if (!fullName.Equals(".all"))
                {
                    members = members.Where(m => m.FullName.ToLower().Contains(fullName.ToLower())).ToList();
                }

                if (!roleId.Equals("all"))
                {
                    members = members.Where(m => m.RoleId == roleId).ToList();
                }
                if (!status.Equals("all"))
                {
                    members = members.Where(m => m.Status == bool.Parse(status));
                }
                return members;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                
                return null;
            }
        }

        public bool UpdateStatus(int id, bool status)
        {
            try
            {
                var member = _db.Members.Find(id);
                if (status == true)
                {
                    member.Status = false;
                }
                else if (status == false)
                {
                    member.Status = true;
                }
                _db.Members.Update(member);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
