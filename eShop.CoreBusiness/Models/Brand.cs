using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eShop.CoreBusiness.Models
{
    public class Brand
    {
        public int BrandId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
