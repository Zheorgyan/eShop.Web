using System.ComponentModel.DataAnnotations;

namespace eShop.CoreBusiness.Models
{
    public class Product
    {

        public Product():base() {}

        public Product(Product product)
        {
            ProductId = product.ProductId;
            BrandId = product.BrandId;
            Name = product.Name;
            Price = product.Price;
            ImageLink = product.ImageLink;
            Description = product.Description;
            Author = product.Author;
            CategoryId = product.CategoryId;
            
        }

        public int ProductId { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public int BrandId { get; set; }
        [Required]
        public string Name { get; set; }
        public double Price { get; set; }
        public string ImageLink { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
    }
}
