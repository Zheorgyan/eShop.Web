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
            var prod = db.Product.FirstOrDefault(x => x.ProductId == product.ProductId);
            if (prod != null)
            {
                return;
            }
            if (db.Product != null && db.Product.Count() > 0)
            {
                var maxId = db.Product.Max(x => x.ProductId);
                product.ProductId = maxId + 1;
            }
            else
            {
                product.ProductId = 1;
            }

            db.Product.Add(product);
            db.SaveChanges();
        }

        public void DeleteProduct(int productId)
        {
            var prod = db.Product.Find(productId);
            if (prod == null) return;
            db.Product.Remove(prod);
            db.SaveChanges();
        }

        public Product GetProduct(int id)
        {
            var product = db.Product.FirstOrDefault(x => x.ProductId == id);
            return product;
        }

        public IEnumerable<Product> GetProducts(string filter = null)
        {
            if (string.IsNullOrWhiteSpace(filter)) return db.Product;
            else return db.Product.Where(x => x.Name == filter);

        }

        public void UpdateProduct(Product product)
        {
            if (db.Product.Find(product.ProductId) == null) return;
            db.Product.Update(product);
            db.SaveChanges();
        }
    }
}
