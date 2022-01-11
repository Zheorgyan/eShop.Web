using eShop.CoreBusiness.Models;

namespace eShop.UseCases.CategoriesScreen
{
    public interface IEditCategoryUseCase
    {
        void Execute(Category category);
    }
}