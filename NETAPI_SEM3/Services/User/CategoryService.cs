using NETAPI_SEM3.Entities;
using NETAPI_SEM3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETAPI_SEM3.Services.User
{
    public interface CategoryService
    {
        public List<Category> getAllCategory();
        public List<NewProperty> PropertyByCategory(int categoryId , int page); 
        public int PropertyByCategoryCount(int categoryId); 
    }
}
