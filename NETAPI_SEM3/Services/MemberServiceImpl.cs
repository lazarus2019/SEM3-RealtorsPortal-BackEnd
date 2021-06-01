
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
        private readonly DatabaseContext DatabaseContext;

        public MemberServiceImpl(DatabaseContext db)
        {
            this.DatabaseContext = db;
        }

        public bool CreateMember(Member member)
        {
            try
            {
                if (member != null)
                {
                    DatabaseContext.Members.Add(member);
                    DatabaseContext.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<Member> GetAllMember()
        {
            return DatabaseContext.Members.Where(m => m.RoleId != "1").ToList();
        }

        public int GetMemberId(string userId)
        {
            return DatabaseContext.Members.FirstOrDefault(m => m.AccountId.Equals(userId)).MemberId;
        }

        public IEnumerable<Member> SearchMember(string fullName, string roleId, string status)
        {
            try
            {

                IEnumerable<Member> members = DatabaseContext.Members.Where(m => m.RoleId != "1").ToList();
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
                var member = DatabaseContext.Members.Find(id);
                if (status == true)
                {
                    member.Status = false;
                }
                else if (status == false)
                {
                    member.Status = true;
                }
                DatabaseContext.Members.Update(member);
                DatabaseContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
