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
        private readonly ProjectSem3DBContext db;

        public CategoryServiceImpl(ProjectSem3DBContext _db)
        {
            this.db = _db;
        }

        public IEnumerable<Category> GetAllCategory()
        {
            return db.Categories.Where(category=> category.IsShow == true).ToList();
        }

		public int createCategory(Category category)
		{
			try
			{
				db.Categories.Add(category);
				db.SaveChanges();
				var lastId = db.Categories.Max(category => category.CategoryId);
				return lastId;
			}
			catch
			{
				return 0;
			}
		}

		public bool updateCategory(Category category)
		{
			try
			{
				var oldCategory = db.Categories.Find(category.CategoryId);
				if (oldCategory != null)
				{
					oldCategory.Name = category.Name;
					db.SaveChanges();
					return true;
				}
				else
				{
					return false;
				}
			}
			catch
			{
				return false;
			}
		}

		public bool deleteCategory(int categoryId)
		{
			try
			{
				var category = db.Categories.Find(categoryId);
				category.IsShow = false;
				db.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public Category findCategory(int categoryId)
		{
			return db.Categories.Find(categoryId);
		}
	}
}
