using eShop.CoreBusiness.Models;

namespace eShop.UseCases.AuthorScreen
{
    public interface IAddAuthorUseCase
    {
        void Execute(Author author);
    }
}