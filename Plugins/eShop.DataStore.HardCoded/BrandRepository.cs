using eShop.CoreBusiness.Models;
using eShop.UseCases.PluginInterfaces.DataStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eShop.DataStore.HardCoded
{
    internal class BrandRepository : IBrandRepository
    {
        private List<Brand> brands;

        public BrandRepository()
        {
            brands = new List<Brand>()
            {
                new Brand { BrandId = 1, Name = "БХВ-Петербург", Description = "тест" },
                new Brand { BrandId = 2, Name = "Вильямс", Description = "тест" },
                new Brand { BrandId = 3, Name = "Бомбора", Description = "тест" },
                new Brand { BrandId = 4, Name = "Прогресс книга", Description = "тест" },
            };
        }
        public void AddBrand(Brand brand)
        {
            if (brands.Any(x => x.Name.Equals(brand.Name, StringComparison.CurrentCultureIgnoreCase))) return;

            if (brands != null && brands.Count > 0)
            {
                var maxId = brands.Max(x => x.BrandId);
                brand.BrandId = maxId + 1;
            }
            else
            {
                brand.BrandId = 1;
            }
            brands.Add(brand);
        }

        public void DeleteBrand(int categoryId)
        {
            brands?.Remove(GetBrandById(categoryId));
        }

        public IEnumerable<Brand> GetBrands()
        {
            return brands;
        }

        public Brand GetBrandById(int brandId)
        {
            return brands?.FirstOrDefault(x => x.BrandId == brandId);
        }

        public void UpdateBrand(Brand brand)
        {
            var brandToUpdate = GetBrandById(brand.BrandId);
            if (brandToUpdate != null)
            {
                brandToUpdate.Name = brand.Name;
                brandToUpdate.Description = brand.Description;
            }
        }
    }
}
