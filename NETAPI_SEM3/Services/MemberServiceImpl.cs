
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

        public bool CreateMember(Member member)
        {
            try
            {
                if (member != null)
                {
                    _db.Members.Add(member);
                    _db.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public int GetAllMember()
        {
            return _db.Members.Where(m => m.RoleId != "SuperAdmin").Count();
        }

        public IEnumerable<Member> GetAllMemberPage(int page)
        {
            var start = 10 * (page - 1);
            var member =  _db.Members.Where(m => m.RoleId != "SuperAdmin").ToList();
            return member.Skip(start).Take(10).ToList();
        }

        public int GetMemberId(string userId)
        {
            return _db.Members.FirstOrDefault(m => m.AccountId.Equals(userId)).MemberId;
        }


        public int SearchMember(string fullName, string position, string status)
        {
            try
            {

                IEnumerable<Member> members = _db.Members.Where(m => m.RoleId != "SuperAdmin").ToList();
                if (!fullName.Equals(".all"))
                {
                    members = members.Where(m => m.FullName.ToLower().Contains(fullName.ToLower())).ToList();
                }

                if (!position.Equals("all"))
                {
                    members = members.Where(m => m.Position.Equals(position)).ToList();
                }
                if (!status.Equals("all"))
                {
                    members = members.Where(m => m.Status == bool.Parse(status));
                }
                return members.Count();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return 0;
            }
        }

        public IEnumerable<Member> SearchMemberPage(string fullName, string position, string status, int page)
        {
            try
            {
                var start = 10 * (page - 1);
                IEnumerable<Member> members = _db.Members.Where(m => m.RoleId != "SuperAdmin").ToList();
                if (!fullName.Equals(".all"))
                {
                    members = members.Where(m => m.FullName.ToLower().Contains(fullName.ToLower())).ToList();
                }

                if (!position.Equals("all"))
                {
                    members = members.Where(m => m.Position.Equals(position)).ToList();
                }
                if (!status.Equals("all"))
                {
                    members = members.Where(m => m.Status == bool.Parse(status));
                }
                return members.Skip(start).Take(10).ToList(); ;
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
