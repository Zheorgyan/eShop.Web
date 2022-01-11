using eShop.CoreBusiness.Models;
using eShop.UseCases.PluginInterfaces.DataStore;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShop.UseCases.BrandsScreen
{
    public class GetBrandByIdUseCase : IGetBrandByIdUseCase
    {
        private readonly IBrandRepository brandRepository;
        public GetBrandByIdUseCase(IBrandRepository brandRepository)
        {
            this.brandRepository = brandRepository;
        }

        public Brand Execute(int brandId)
        {
            return brandRepository.GetBrandById(brandId);
        }
    }
}
