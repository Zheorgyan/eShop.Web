using eShop.CoreBusiness.Models;
using eShop.UseCases.PluginInterfaces.DataStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eShop.DataStore.SQL.EF
{
    public class BrandRepository : IBrandRepository
    {
        private readonly eShopContext db;

        public BrandRepository(eShopContext db)
        {
            this.db = db;
        }
        public void AddBrand(Brand brand)
        {
            db.Brand.Add(brand);
        }

        public void DeleteBrand(int brandId)
        {
            var brand = GetBrandById(brandId);
            if (brand == null)
            {
                return;
            }
            db.Brand.Remove(brand);
        }

        public Brand GetBrandById(int brandId)
        {
            return db.Brand.FirstOrDefault(x => x.BrandId == brandId);
        }

        public IEnumerable<Brand> GetBrands()
        {
            return db.Brand.ToList();
        }

        public void UpdateBrand(Brand brand)
        {
            var br = GetBrandById(brand.BrandId);
            if (br == null)
            {
                return;
            }
            db.Brand.Update(brand);
        }
    }
}
