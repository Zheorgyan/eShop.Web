using eShop.CoreBusiness.Models;

namespace eShop.UseCases.AddProductUseCase
{
    public interface IAddProductUseCase
    {
        void Execute(Product product);
    }
}