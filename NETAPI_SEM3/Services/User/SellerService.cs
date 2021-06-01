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
        public List<Member> getAllSeller(int page);
        public int getIdSeller();
        public List<Member> getAllAgent(int page);
        public int getIdAgent();
        public NewMember SellerDetails(int sellerId);
        public List<Property> LoadPropertyId(int sellerId);
        public List<Image> getGallery(int newsId);

    }
}
