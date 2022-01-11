using eShop.CoreBusiness.Models;

namespace eShop.UseCases.CategoriesScreen
{
    public interface IAddCategoryUseCase
    {
        void Execute(Category category);
    }
}