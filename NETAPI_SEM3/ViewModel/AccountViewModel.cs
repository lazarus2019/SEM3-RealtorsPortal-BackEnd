using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETAPI_SEM3.ViewModel
{
    public class AccountViewModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Position { get; set; }
        public bool RememberMe { get; set; }
        public string ClientURI { get; set; }
        public string Role { get; set; }
    }
}
