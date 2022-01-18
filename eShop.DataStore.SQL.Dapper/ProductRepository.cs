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
                                ([BrandId]
                                ,[CategoryId]
                                ,[AuthorId]
                                ,[Name]
                                ,[Price]
                                ,[ImageLink]
                                ,[Description])
                        OUTPUT INSERTED.ProductId
                            VALUES
                                (@BrandId
                                ,@CategoryId
                                ,@AuthorId
                                ,@Name
                                ,@Price
                                ,@ImageLink
                                ,@Description)";

            var productId = dataAccess.QuerySingle<int, Product>(sql, product);

            AuthorForProduct authorForProduct = new AuthorForProduct()
            {
                ProductId = productId,
                AuthorId = product.AuthorId
            };

            sql = @"INSERT INTO [dbo].[AuthorForProduct]
                                ([AuthorId]
                                ,[ProductId])
                        VALUES
                                (@AuthorId
                                ,@ProductId)";

            dataAccess.ExecuteCommand(sql, authorForProduct);

            BrandForProduct brandForProduct = new BrandForProduct()
            {
                ProductId = productId,
                BrandId = product.BrandId
            };

            sql = @"INSERT INTO [dbo].[BrandForProduct]
                                ([BrandId]
                                ,[ProductId])
                        VALUES
                                (@BrandId
                                ,@ProductId)";

            dataAccess.ExecuteCommand(sql, brandForProduct);
        }

        public void DeleteProduct(int productId)
        {
            var prod = GetProduct(productId);
            if (prod == null) return;

            var sql = $@"DELETE FROM Product WHERE ProductId = {prod.ProductId}";
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
            {
                var sql = @"SELECT p.ProductId, p.Name, p.Price, p.Description, p.ImageLink, p.BrandId, p.AuthorId, p.CategoryId FROM Product p 
                            join Author a on a.AuthorId = p.AuthorId
                            join Brand b on b.BrandId = p.BrandId
                            join Category c on c.CategoryId = p.CategoryId
                            WHERE p.Name like '%' + @Filter + '%' OR a.FirstName like '%' + @Filter + '%' OR a.LastName like '%' + @Filter + '%'
                            OR b.Name like '%' + @Filter + '%' OR c.Name like '%' + @Filter + '%'";
                products = dataAccess.Query<Product, dynamic>(sql, new { Filter = filter });
            }

            return products;
        }

        public void UpdateProduct(Product product)
        {
            var prod = GetProduct(product.ProductId);
            if (prod == null) return;

            var sql = @"UPDATE [Product]
                          SET [BrandId] = @BrandId
                          ,[CategoryId] = @CategoryId
                          ,[AuthorId] = @AuthorId
                          ,[Name] = @Name
                          ,[Price] = @Price
                          ,[ImageLink] = @ImageLink
                          ,[Description] = @Description
                      WHERE ProductId = @ProductId";

            dataAccess.ExecuteCommand(sql, product);

            sql = @"UPDATE [AuthorForProduct]
                        SET [AuthorId] = @AuthorId
                        ,[ProductId] = @ProductId";

            dataAccess.ExecuteCommand(sql, product);

            sql = @"UPDATE [BrandForProduct]
                        SET [BrandId] = @BrandId
                        ,[ProductId] = @ProductId";

            dataAccess.ExecuteCommand(sql, product);
        }
    }
}
