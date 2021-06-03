using NETAPI_SEM3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETAPI_SEM3.Entities
{
    public class MemberNews
    {
        public int MemberId { get; set; }
        public string RoleId { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public string Photo { get; set; }
        public DateTime CreateDate { get; set; }
        

    }
}
