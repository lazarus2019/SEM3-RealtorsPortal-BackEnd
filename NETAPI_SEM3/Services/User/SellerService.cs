using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NETAPI_SEM3.Entities;
using NETAPI_SEM3.Models;

namespace NETAPI_SEM3.Services.User
{
    public interface SellerService
    {
        public List<Member> LoadSearchSeller();
        public List<Member> LoadSeller();
        public List<Member> LoadAgent();
        public NewMember SellerDetails(int sellerId);
        public List<Property> LoadPropertyId(int sellerId);

    }
}
