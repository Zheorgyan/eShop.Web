using eShop.CoreBusiness.Models;

namespace eShop.UseCases.BrandsScreen
{
    public interface IGetBrandByIdUseCase
    {
        Brand Execute(int brandId);
    }
}