using eShop.CoreBusiness.Models;

namespace eShop.UseCases.AuthorScreen
{
    public interface IGetAuthorByIdUseCase
    {
        Author Execute(int authorId);
    }
}