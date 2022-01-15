using eShop.CoreBusiness.Models;
using eShop.UseCases.PluginInterfaces.DataStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eShop.DataStore.SQL.Dapper
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IDataAccess dataAccess;

        private List<Category> categories;
        public CategoryRepository(IDataAccess dataAccess)
        {
            this.dataAccess = dataAccess;
        }

        public void AddCategory(Category category)
        {
            categories = GetCategories().ToList();
            if (categories.Any(x => x.Name.Equals(category.Name, StringComparison.OrdinalIgnoreCase)))
            {
                return;
            }
            if (categories != null && categories.Count > 0)
            {
                var maxId = categories.Max(x => x.CategoryId);
                category.CategoryId = maxId + 1;
            }
            else
            {
                category.CategoryId = 1;
            }
            var sql = @"INSERT INTO [dbo].[Category]
                                ([Name]
                                ,[Description])
                            VALUES
                                (@Name
                                ,@Description)";

            dataAccess.ExecuteCommand(sql, category);
        }

        public void DeleteCategory(int categoryId)
        {
            var prod = GetCategoryById(categoryId);
            if (prod == null) return;

            var sql = $@"DELETE FROM Category WHERE CategoryId = {categoryId}";
            dataAccess.ExecuteCommand(sql, categoryId);
        }

        public IEnumerable<Category> GetCategories()
        {
            return categories = dataAccess.Query<Category, dynamic>("SELECT * FROM Category", new { });
        }
        public Category GetCategoryById(int categoryId)
        {
            return dataAccess.QuerySingle<Category, dynamic>("SELECT * FROM Category WHERE CategoryId = @CategoryId", new { CategoryId = categoryId });
        }

        public void UpdateCategory(Category category)
        {
            var prod = GetCategoryById(category.CategoryId);
            if (prod == null) return;

            var sql = @"UPDATE [Category]
                          SET [Name] = @Name
                          ,[Description] = @Description
                      WHERE CategoryId = @CategoryId";

            dataAccess.ExecuteCommand(sql, category);
        }
    }
}
