using eShop.CoreBusiness.Models;
using System.Collections.Generic;

namespace eShop.UseCases.AuthorScreen
{
    public interface IViewAuthorsUseCase
    {
        IEnumerable<Author> Execute();
    }
}