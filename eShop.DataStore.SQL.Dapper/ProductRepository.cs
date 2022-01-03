using eShop.CoreBusiness.Models;
using eShop.UseCases.PluginInterfaces.DataStore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace eShop.DataStore.SQL.Dapper
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDataAccess dataAccess;

        private List<Product> products;
        public ProductRepository(IDataAccess dataAccess)
        {
            this.dataAccess = dataAccess;
        }

        public void AddProduct(Product product)
        {
            products = GetProducts().ToList();
            if (products.Any(x => x.Name.Equals(product.Name, StringComparison.OrdinalIgnoreCase)))
            {
                return;
            }
            if (products != null && products.Count > 0)
            {
                var maxId = products.Max(x => x.ProductId);
                product.ProductId = maxId + 1;
            }
            else
            {
                product.ProductId = 1;
            }
            var sql = @"INSERT INTO [dbo].[Product]
                                ([ProductId]
                                ,[Brand]
                                ,[Author]
                                ,[Name]
                                ,[Price]
                                ,[ImageLink]
                                ,[Description])
                            VALUES
                                (@ProductId
                                ,@Brand
                                ,@Author
                                ,@Name
                                ,@Price
                                ,@ImageLink
                                ,@Description)";

            dataAccess.ExecuteCommand(sql, product);
            products.Add(product);
        }

        public void DeleteProduct(int productId)
        {
            var prod = GetProduct(productId);
            if (prod == null) return;

            var sql = @"DELETE FROM [dbo].[Product] WHERE [ProductId] = @ProductId";
            dataAccess.ExecuteCommand(sql, productId);
        }

        public Product GetProduct(int id)
        {
            return dataAccess.QuerySingle<Product, dynamic>("SELECT * FROM Product WHERE ProductId = @ProductId", new { ProductId = id });
        }

        public IEnumerable<Product> GetProducts(string filter = null)
        {
            if (string.IsNullOrWhiteSpace(filter))
                products = dataAccess.Query<Product, dynamic>("SELECT * FROM Product", new { });
            else
                products = dataAccess.Query<Product, dynamic>("SELECT * FROM Product WHERE Name like '%' + @Filter + '%'", new { Filter = filter });

            return products.AsEnumerable();
        }

        public void UpdateProduct(Product product)
        {
            var prod = GetProduct(product.ProductId);
            if (prod == null) return;

            var sql = @"UPDATE [Product]
                          SET [ProductId] = @ProductId
                          ,[Brand] = @Brand
                          ,[Author] = @Author
                          ,[Name] = @Name
                          ,[Price] = @Price
                          ,[ImageLink] = @ImageLink
                          ,[Description] = @Description
                      WHERE ProductId = @ProductId";

            dataAccess.ExecuteCommand(sql, product);
        }
    }
}
