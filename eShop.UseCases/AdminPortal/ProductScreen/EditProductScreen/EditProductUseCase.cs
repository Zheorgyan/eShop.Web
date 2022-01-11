using eShop.CoreBusiness.Models;
using eShop.UseCases.PluginInterfaces.DataStore;
namespace eShop.UseCases.EditProductScreen
{
    public class EditProductUseCase : IEditProductUseCase
    {
        private readonly IProductRepository productRepository;

        public EditProductUseCase(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public void Execute(Product product)
        {
            productRepository.UpdateProduct(product);
        }
    }
}
