using eShop.CoreBusiness.Models;
using eShop.UseCases.PluginInterfaces.DataStore;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShop.UseCases.AuthorScreen
{
    public class ViewAuthorsUseCase : IViewAuthorsUseCase
    {
        private IAuthorRepository authorRepository;
        public ViewAuthorsUseCase(IAuthorRepository authorRepository)
        {
            this.authorRepository = authorRepository;
        }

        public IEnumerable<Author> Execute()
        {
            return authorRepository.GetAuthors();
        }
    }
}
