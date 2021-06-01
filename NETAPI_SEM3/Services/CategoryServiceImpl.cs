using NETAPI_SEM3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETAPI_SEM3.Services
{
    public class CategoryServiceImpl : CategoryService
    {
        private readonly DatabaseContext DatabaseContext;

        public CategoryServiceImpl(DatabaseContext db)
        {
            this.DatabaseContext = db;
        }

        public IEnumerable<Category> GetAllCategory()
        {
            return DatabaseContext.Categories.ToList();
        }
    }
}
