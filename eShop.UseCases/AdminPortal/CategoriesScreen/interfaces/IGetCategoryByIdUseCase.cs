using eShop.CoreBusiness.Models;

namespace eShop.UseCases.CategoriesScreen
{
    public interface IGetCategoryByIdUseCase
    {
        Category Execute(int categoryId);
    }
}