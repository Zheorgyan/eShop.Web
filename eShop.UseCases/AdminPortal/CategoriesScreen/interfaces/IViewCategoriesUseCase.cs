using eShop.CoreBusiness.Models;
using System.Collections.Generic;

namespace eShop.UseCases.CategoriesScreen
{
    public interface IViewCategoriesUseCase
    {
        IEnumerable<Category> Execute();
    }
}