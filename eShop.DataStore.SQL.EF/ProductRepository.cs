using eShop.CoreBusiness.Models;
using eShop.UseCases.PluginInterfaces.DataStore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace eShop.DataStore.SQL.EF
{
    public class ProductRepository : IProductRepository
    {
        private readonly eShopContext db;

        public ProductRepository(eShopContext db)
        {
            this.db = db;
        }

        public void AddProduct(Product product)
        {
            if (db.Products.Any(x => x.Name.Equals(product.Name, StringComparison.OrdinalIgnoreCase)))
            {
                return;
            }
            if (db.Products != null && db.Products.Count() > 0)
            {
                var maxId = db.Products.Max(x => x.ProductId);
                product.ProductId = maxId + 1;
            }
            else
            {
                product.ProductId = 1;
            }

            db.Products.Add(product);
            db.SaveChanges();
        }

        public void DeleteProduct(int productId)
        {
            var prod = db.Products.Find(productId);
            if (prod == null) return;
            db.Products.Remove(prod);
            db.SaveChanges();
        }

        public Product GetProduct(int id)
        {
            return db.Products.Where(x => x.ProductId == id) as Product;
        }

        public IEnumerable<Product> GetProducts(string filter = null)
        {
            if (string.IsNullOrWhiteSpace(filter)) return db.Products.ToList();
            else return db.Products.Where(x => x.Name == filter || x.Author == filter || x.Brand == filter).ToList();

        }

        public void UpdateProduct(Product product)
        {
            if (db.Products.Find(product.ProductId) == null) return;
            db.Products.Update(product);
            db.SaveChanges();
        }
    }
}
