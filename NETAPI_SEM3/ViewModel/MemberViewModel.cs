using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETAPI_SEM3.ViewModel
{
    public class MemberViewModel
    {
        public int MemberId { get; set; }
        public int RoleId { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public string Position { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }
        public string Photo { get; set; }
        public DateTime createDate { get; set; }
    }
}
