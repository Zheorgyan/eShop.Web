namespace eShop.CoreBusiness.Models
{
    public class Product
    {

        public Product():base() {}

        public Product(Product product)
        {
            ProductId = product.ProductId;
            Brand = product.Brand;
            Name = product.Name;
            Price = product.Price;
            ImageLink = product.ImageLink;
            Description = product.Description;
            Author = product.Author;       
        }

        public int ProductId { get; set; }
        public string Brand { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string ImageLink { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
    }
}
