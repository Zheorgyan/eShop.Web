using System;
using System.Collections.Generic;
using System.Text;

namespace eShop.CoreBusiness.Models
{
    public class AuthorForProduct
    {
        public int AuthorForProductId { get; set; }
        public int AuthorId { get; set; }
        public int ProductId { get; set; }

        public Author Author { get; set; }

        public Product Product { get; set; }
    }
}
