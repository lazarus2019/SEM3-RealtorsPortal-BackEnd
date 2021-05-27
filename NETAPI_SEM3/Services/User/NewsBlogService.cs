using NETAPI_SEM3.Entities;
using NETAPI_SEM3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETAPI_SEM3.Services.User
{
    public interface NewsBlogService
    {
        public List<NewCategory> loadnewCategory();
        public NewCategory loadnewCategoryId(int categoryId);
        public List<Image> getGallery(int newsId);
    }
}
