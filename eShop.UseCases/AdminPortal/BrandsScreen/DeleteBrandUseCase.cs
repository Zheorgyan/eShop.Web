using eShop.CoreBusiness.Models;
using eShop.UseCases.PluginInterfaces.DataStore;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShop.UseCases.BrandsScreen
{
    public class DeleteBrandUseCase : IDeleteBrandUseCase
    {
        private IBrandRepository brandRepository;
        public DeleteBrandUseCase(IBrandRepository brandRepository)
        {
            this.brandRepository = brandRepository;
        }

        public void Execute(int brandId)
        {
            brandRepository.DeleteBrand(brandId);
        }
    }
}
