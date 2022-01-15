using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eShop.CoreBusiness.Models
{
    public class BrandForProduct
    {
        [Key]
        public int BrandForProductId { get; set; }
        public int ProductId { get; set; }
        public int BrandId { get; set; }

        public Brand Brand { get; set; }
        public Product Product { get; set; }
    }
}
