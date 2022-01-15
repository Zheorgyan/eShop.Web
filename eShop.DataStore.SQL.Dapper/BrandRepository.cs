using eShop.CoreBusiness.Models;
using eShop.UseCases.PluginInterfaces.DataStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eShop.DataStore.SQL.Dapper
{
    public class BrandRepository : IBrandRepository
    {
        private readonly IDataAccess dataAccess;

        private List<Brand> brands;
        public BrandRepository(IDataAccess dataAccess)
        {
            this.dataAccess = dataAccess;
        }

        public void AddBrand(Brand brand)
        {
            brands = GetBrands().ToList();
            if (brands.Any(x => x.Name.Equals(brand.Name, StringComparison.OrdinalIgnoreCase)))
            {
                return;
            }
            if (brands != null && brands.Count > 0)
            {
                var maxId = brands.Max(x => x.BrandId);
                brand.BrandId = maxId + 1;
            }
            else
            {
                brand.BrandId = 1;
            }
            var sql = @"INSERT INTO [dbo].[Brand]
                                ([Name]
                                ,[Description])
                            VALUES
                                (@Name
                                ,@Description)";

            dataAccess.ExecuteCommand(sql, brand);
        }

        public void DeleteBrand(int brandId)
        {
            var brand = GetBrandById(brandId);
            if (brand == null) return;

            var sql = $@"DELETE FROM Brand WHERE BrandId = {brandId}";
            dataAccess.ExecuteCommand(sql, brandId);
        }

        public Brand GetBrandById(int id)
        {
            return dataAccess.QuerySingle<Brand, dynamic>("SELECT * FROM Brand WHERE BrandId = @BrandId", new { BrandId = id });
        }

        public IEnumerable<Brand> GetBrands()
        {
           return brands = dataAccess.Query<Brand, dynamic>("SELECT * FROM Brand", new { });
        }

        public void UpdateBrand(Brand brand)
        {
            var brn = GetBrandById(brand.BrandId);
            if (brn == null) return;

            var sql = @"UPDATE [Brand]
                        SET [Name] = @Name
                           ,[Description] = @Description
                        WHERE BrandId = @BrandId";

            dataAccess.ExecuteCommand(sql, brand);
        }
    }
}
