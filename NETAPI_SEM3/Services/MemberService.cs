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
        public IEnumerable<Member> GetAllMember();
        public IEnumerable<Member> SearchMember(string fullName, string roleId, string status);
        public bool UpdateStatus(int id, bool status);
        public int GetMemberId(string userId);
        public bool CreateMember(Member member);


    }
}
