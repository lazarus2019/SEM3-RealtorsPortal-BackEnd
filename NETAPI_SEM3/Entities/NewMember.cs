using NETAPI_SEM3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETAPI_SEM3.Entities
{
    public class NewMember
    {
        public int MemberId { get; set; }
        public int? RoleId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }
        public string Photo { get; set; }
        public DateTime CreateDate { get; set; }
        public string VerifyCode { get; set; }
        public string Description { get; set; }

    }
}
