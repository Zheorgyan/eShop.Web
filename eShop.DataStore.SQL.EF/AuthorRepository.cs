using eShop.CoreBusiness.Models;
using eShop.UseCases.PluginInterfaces.DataStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eShop.DataStore.SQL.EF
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly eShopContext db;

        public AuthorRepository(eShopContext db)
        {
            this.db = db;
        }
        public void AddAuthor(Author author)
        {
            db.Author.Add(author);
            var authorForProduct = new AuthorForProduct();
            authorForProduct.AuthorId = author.AuthorId;
            db.AuthorForProduct.Add(authorForProduct);
        }

        public void DeleteAuthor(int authorId)
        {
            var author = GetAuthorById(authorId);
            if (author == null)
            {
                return;
            }
            db.Author.Remove(author);
        }

        public Author GetAuthorById(int authorId)
        {
            return db.Author.FirstOrDefault(x => x.AuthorId == authorId);
        }

        public IEnumerable<Author> GetAuthors()
        {
            return db.Author.ToList();
        }

        public void UpdateAuthor(Author author)
        {
            var br = GetAuthorById(author.AuthorId);
            if (br == null)
            {
                return;
            }
            db.Author.Update(author);
        }
    }
}
