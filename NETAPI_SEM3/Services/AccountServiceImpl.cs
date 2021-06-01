using Microsoft.EntityFrameworkCore;
using NETAPI_SEM3.Models;
using NETAPI_SEM3.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Diagnostics;

namespace NETAPI_SEM3.Services
{
    public class AccountServiceImpl : AccountService
    {
        private readonly ProjectSem3DBContext _db;


        public AccountServiceImpl(ProjectSem3DBContext db

            )
        {
            this._db = db;

        }

        public IEnumerable<Member> GetAllMember()
        {
            return _db.Members.Where(m => m.Status == true).ToList();
        }


        public Member Find(string username)
        {
            return _db.Members.SingleOrDefault(m => m.Username.Equals(username));
        }

    }
}
