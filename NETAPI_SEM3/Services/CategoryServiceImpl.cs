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

        public int createCategory(Category category)
        {
            try
            {
                _db.Categories.Add(category);
                _db.SaveChanges();
                var lastId = _db.Categories.Max(category => category.CategoryId);
                return lastId;
            }
            catch
            {
                return 0;
            }
        }
    }
}
