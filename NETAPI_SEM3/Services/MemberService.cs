using NETAPI_SEM3.Models;
using NETAPI_SEM3.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETAPI_SEM3.Services
{
    public interface MemberService
    {
        public int GetAllMember();
        public IEnumerable<Member> GetAllMemberPage(int page);
        public int SearchMember(string fullName, string roleId, string status);
        public IEnumerable<Member> SearchMemberPage(string fullName, string roleId, string status, int page);
        public bool UpdateStatus(int id, bool status);
        public int GetMemberId(string userId);
        public IEnumerable<string> GetPosition();
        public bool CreateMember(Member member);
    }
}
