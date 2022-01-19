using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace eShop.CoreBusiness.Models
{
    public class Product
    {
        public Product() : base() { }

        public Product(Product product)
        {
            ProductId = product.ProductId;
            BrandId = product.BrandId;
            AuthorId = product.AuthorId;
            CategoryId = product.CategoryId;
            Name = product.Name;
            Price = product.Price;
            ImageLink = product.ImageLink;
            Description = product.Description;

        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public int BrandId { get; set; }
        [Required]
        public int AuthorId { get; set; }
        [Required]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImageLink { get; set; }
        public string Description { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public Category Category { get; set; }
        public List<BrandForProduct> BrandForProducts { get; set; }
        public List<AuthorForProduct> AuthorForProducts { get; set; }
    }
}
