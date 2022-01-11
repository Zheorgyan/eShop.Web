using eShop.CoreBusiness.Models;
using eShop.UseCases.PluginInterfaces.DataStore;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShop.UseCases.BrandsScreen
{
    public class ViewBrandsUseCase : IViewBrandsUseCase
    {
        private readonly IBrandRepository brandRepository;

        public ViewBrandsUseCase(IBrandRepository brandRepository)
        {
            this.brandRepository = brandRepository;
        }

        public IEnumerable<Brand> Execute()
        {
            return brandRepository.GetBrands();
        }
    }
}
