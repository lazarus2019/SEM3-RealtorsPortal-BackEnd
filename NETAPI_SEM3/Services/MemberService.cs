using NETAPI_SEM3.Entities;
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
    }
}
