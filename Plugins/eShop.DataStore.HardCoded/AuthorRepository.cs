using eShop.CoreBusiness.Models;
using eShop.UseCases.PluginInterfaces.DataStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eShop.DataStore.HardCoded
{
    public class AuthorRepository : IAuthorRepository
    {
        private List<Author> authors;

        public AuthorRepository()
        {
            authors = new List<Author>()
            {
                new Author { AuthorId = 1, FirstName = "Джеффри", LastName = "Рихтер" },
                new Author { AuthorId = 2, FirstName = "Алексей", LastName = "Васильев", SecondName = "Николаевич" },
                new Author { AuthorId = 3, FirstName = "Джон", LastName = "Скит" },
                new Author { AuthorId = 4, FirstName = "Михаил", LastName = "Фленов", SecondName = "Евгеньевич" }
            };
        }
        public void AddAuthor(Author author)
        {
            if (authors.Any(x => x.FirstName.Equals(author.FirstName, StringComparison.CurrentCultureIgnoreCase))) return;

            if (authors != null && authors.Count > 0)
            {
                var maxId = authors.Max(x => x.AuthorId);
                author.AuthorId = maxId + 1;
            }
            else
            {
                author.AuthorId = 1;
            }
            authors.Add(author);
        }

        public void DeleteAuthor(int categoryId)
        {
            authors?.Remove(GetAuthorById(categoryId));
        }

        public IEnumerable<Author> GetAuthors()
        {
            return authors;
        }

        public Author GetAuthorById(int authorId)
        {
            return authors?.FirstOrDefault(x => x.AuthorId == authorId);
        }

        public void UpdateAuthor(Author author)
        {
            var authorToUpdate = GetAuthorById(author.AuthorId);
            if (authorToUpdate != null)
            {
                authorToUpdate.FirstName = author.FirstName;
                authorToUpdate.LastName = author.LastName;
                authorToUpdate.SecondName = author.SecondName;
            }
        }
    }
}
