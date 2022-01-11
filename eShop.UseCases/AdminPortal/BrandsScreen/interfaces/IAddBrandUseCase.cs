using eShop.CoreBusiness.Models;

namespace eShop.UseCases.BrandsScreen
{
    public interface IAddBrandUseCase
    {
        void Execute(Brand brand);
    }
}