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
        private readonly DatabaseContext _db;

        public CategoryServiceImpl(DatabaseContext db)
        {
            this._db = db;
        }

        public IEnumerable<Category> GetAllCategory()
        {
            return _db.Categories.ToList();
        }
    }
}
