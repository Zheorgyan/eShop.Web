using eShop.CoreBusiness.Models;
using eShop.UseCases.PluginInterfaces.DataStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eShop.DataStore.SQL.EF
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly eShopContext db;

        public CategoryRepository(eShopContext db)
        {
            this.db = db;
        }

        public void AddCategory(Category category)
        {
            db.Category.Add(category);
        }

        public void DeleteCategory(int categoryId)
        {
            var cat = GetCategoryById(categoryId);
            if (cat == null)
            {
                return;
            }
            db.Category.Remove(cat);
        }

        public Brand GetBrandById(int brandId)
        {
            return db.Brand.FirstOrDefault(x => x.BrandId == brandId);
        }

        public IEnumerable<Category> GetCategories()
        {
            return db.Category.ToList();
        }

        public Category GetCategoryById(int categoryId)
        {
            return db.Category.FirstOrDefault(x => x.CategoryId == categoryId);
        }


        public void UpdateCategory(Category category)
        {
            var cat = GetCategoryById(category.CategoryId);
            if (cat == null)
            {
                return;
            }
            db.Category.Update(category);
        }
    }
}
