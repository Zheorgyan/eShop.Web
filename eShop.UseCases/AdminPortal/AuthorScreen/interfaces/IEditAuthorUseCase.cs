using eShop.CoreBusiness.Models;

namespace eShop.UseCases.AuthorScreen
{
    public interface IEditAuthorUseCase
    {
        void Execute(Author author);
    }
}