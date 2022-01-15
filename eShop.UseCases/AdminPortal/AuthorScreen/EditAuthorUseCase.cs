using eShop.CoreBusiness.Models;
using eShop.UseCases.PluginInterfaces.DataStore;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShop.UseCases.AuthorScreen
{
    public class EditAuthorUseCase : IEditAuthorUseCase
    {
        private IAuthorRepository authorRepository;
        public EditAuthorUseCase(IAuthorRepository authorRepository)
        {
            this.authorRepository = authorRepository;
        }

        public void Execute(Author author)
        {
            authorRepository.UpdateAuthor(author);
        }
    }
}
