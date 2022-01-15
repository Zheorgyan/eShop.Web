using eShop.CoreBusiness.Models;
using eShop.UseCases.PluginInterfaces.DataStore;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShop.UseCases.AuthorScreen
{
    public class DeleteAuthorUseCase : IDeleteAuthorUseCase
    {
        private IAuthorRepository authorRepository;
        public DeleteAuthorUseCase(IAuthorRepository authorRepository)
        {
            this.authorRepository = authorRepository;
        }

        public void Execute(int authorId)
        {
            authorRepository.DeleteAuthor(authorId);
        }
    }
}
