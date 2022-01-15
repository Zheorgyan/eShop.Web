using eShop.CoreBusiness.Models;
using System.Collections.Generic;

namespace eShop.UseCases.PluginInterfaces.DataStore
{
    public interface IAuthorRepository
    {
        void AddAuthor(Author author);
        void DeleteAuthor(int categoryId);
        Author GetAuthorById(int authorId);
        IEnumerable<Author> GetAuthors();
        void UpdateAuthor(Author author);
    }
}