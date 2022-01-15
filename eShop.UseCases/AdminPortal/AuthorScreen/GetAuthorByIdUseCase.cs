using eShop.CoreBusiness.Models;
using eShop.UseCases.PluginInterfaces.DataStore;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShop.UseCases.AuthorScreen
{
    public class GetAuthorByIdUseCase : IGetAuthorByIdUseCase
    {
        private IAuthorRepository authorRepository;
        public GetAuthorByIdUseCase(IAuthorRepository authorRepository)
        {
            this.authorRepository = authorRepository;
        }

        public Author Execute(int authorId)
        {
            return authorRepository.GetAuthorById(authorId);
        }
    }
}
