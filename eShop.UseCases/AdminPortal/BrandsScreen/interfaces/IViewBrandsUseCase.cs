using eShop.CoreBusiness.Models;
using System.Collections.Generic;

namespace eShop.UseCases.BrandsScreen
{
    public interface IViewBrandsUseCase
    {
        IEnumerable<Brand> Execute();
    }
}