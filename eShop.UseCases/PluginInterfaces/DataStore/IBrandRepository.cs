using eShop.CoreBusiness.Models;
using System.Collections.Generic;

namespace eShop.UseCases.PluginInterfaces.DataStore
{
    public interface IBrandRepository
    {
        void AddBrand(Brand brand);
        void DeleteBrand(int brandId);
        Brand GetBrandById(int brandId);
        IEnumerable<Brand> GetBrands();
        void UpdateBrand(Brand brand);
    }
}