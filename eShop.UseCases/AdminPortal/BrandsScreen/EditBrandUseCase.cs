using eShop.CoreBusiness.Models;
using eShop.UseCases.PluginInterfaces.DataStore;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShop.UseCases.BrandsScreen
{
    public class EditBrandUseCase : IEditBrandUseCase
    {
        private IBrandRepository brandRepository;
        public EditBrandUseCase(IBrandRepository brandRepository)
        {
            this.brandRepository = brandRepository;
        }

        public void Execute(Brand brand)
        {
            brandRepository.UpdateBrand(brand);
        }
    }
}
