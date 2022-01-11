using eShop.CoreBusiness.Models;

namespace eShop.UseCases.EditProductScreen
{
    public interface IEditProductUseCase
    {
        void Execute(Product product);
    }
}