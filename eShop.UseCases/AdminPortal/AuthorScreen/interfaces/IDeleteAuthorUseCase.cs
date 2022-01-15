using eShop.CoreBusiness.Models;

namespace eShop.UseCases.AuthorScreen
{
    public interface IDeleteAuthorUseCase
    {
        void Execute(int authorId);
    }
}