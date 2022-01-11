using eShop.CoreBusiness.Models;
using eShop.UseCases.PluginInterfaces.DataStore;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShop.UseCases.BrandsScreen
{
    public class AddBrandUseCase : IAddBrandUseCase
    {
        private IBrandRepository brandRepository;
        public AddBrandUseCase(IBrandRepository brandRepository)
        {
            this.brandRepository = brandRepository;
        }

        public void Execute(Brand brand)
        {
            brandRepository.AddBrand(brand);
        }
    }
}
