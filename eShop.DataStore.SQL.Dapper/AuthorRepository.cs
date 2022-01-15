using eShop.CoreBusiness.Models;
using eShop.UseCases.PluginInterfaces.DataStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eShop.DataStore.SQL.Dapper
{
    public class AuthorRepository : IAuthorRepository
    {
        private List<Author> authors;
        private readonly IDataAccess dataAccess;
        public AuthorRepository(IDataAccess dataAccess)
        {
            this.dataAccess = dataAccess;
        }

        public void AddAuthor(Author author)
        {
            authors = GetAuthors().ToList();
            if (authors.Any(x => x.FirstName.Equals(author.FirstName, StringComparison.OrdinalIgnoreCase)))
            {
                return;
            }
            if (authors != null && authors.Count > 0)
            {
                var maxId = authors.Max(x => x.AuthorId);
                author.AuthorId = maxId + 1;
            }
            else
            {
                author.AuthorId = 1;
            }
            var sql = @"INSERT INTO [dbo].[Author]
                                ([FirstName]
                                ,[LastName]
                                ,[SecondName])
                            VALUES
                                (@FirstName
                                ,@LastName
                                ,@SecondName)";

            dataAccess.ExecuteCommand(sql, author);
        }

        public void DeleteAuthor(int authorId)
        {
            var aut = GetAuthorById(authorId);
            if (aut == null)
            {
                return;
            }

            var sql = $@"DELETE FROM Author WHERE AuthorId = {authorId}";
            dataAccess.ExecuteCommand(sql, authorId);
        }

        public Author GetAuthorById(int authorId)
        {
            return dataAccess.QuerySingle<Author, dynamic>("SELECT * FROM Author WHERE AuthorId = @AuthorId", new { AuthorId = authorId });
        }

        public IEnumerable<Author> GetAuthors()
        {
            return authors = dataAccess.Query<Author, dynamic>("SELECT * FROM Author", new { });
        }

        public void UpdateAuthor(Author author)
        {
            var aut = GetAuthorById(author.AuthorId);
            if (aut == null)
            {
                return;
            }
            var sql = @"UPDATE [Author]
                        SET [FirstName] = @FirstName
                            ,[LastName] = @LastName
                            ,[SecondName] = @SecondName
                        WHERE AuthorId = @AuthorId";
            dataAccess.ExecuteCommand(sql, author);
        }
    }
}
