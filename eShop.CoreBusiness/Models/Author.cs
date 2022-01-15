using System;
using System.Collections.Generic;
using System.Text;

namespace eShop.CoreBusiness.Models
{
    public class Author
    {
        public Author() : base()
        {

        }

        public Author(Author author)
        {
            AuthorId = author.AuthorId;
            FirstName = author.FirstName;
            LastName = author.LastName;
            SecondName = author.SecondName;
        }
        public int AuthorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SecondName { get; set; }

        public List<AuthorForProduct> AuthorForProducts { get; set; }
    }
}
