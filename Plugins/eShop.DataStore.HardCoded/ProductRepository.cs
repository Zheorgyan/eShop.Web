﻿using eShop.CoreBusiness.Models;
using eShop.UseCases.PluginInterfaces.DataStore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace eShop.DataStore.HardCoded
{
    public class ProductRepository : IProductRepository
    {
        private List<Product> products;

        public ProductRepository()
        {
            products = new List<Product>
            {
                new Product
                { 
                    ProductId = 495,
                    CategoryId = 1,
                    BrandId = 1,
                    AuthorId = 1,
                    Name = "CLR via C#. Программирование на платформе Microsoft .NET Framework 4.5 на языке C#. 4-е изд.", 
                    Price = 1825,
                    ImageLink = "https://cdn1.ozone.ru/s3/multimedia-i/6170125470.jpg",
                    Description = "Эта книга, выходящая в четвертом издании и уже ставшая классическим учебником по программированию, подробно описывает внутреннее устройство и функционирование общеязыковой исполняющей среды (CLR) Microsoft .NET Framework версии 4.5. Написанная признанным экспертом в области программирования Джеффри Рихтером, много лет являющимся консультантом команды разработчиков .NET Framework компании Microsoft, книга научит вас создавать по-настоящему надежные приложения любого вида, в том числе с использованием Microsoft Silverlight, ASP.NET, Windows Presentation Foundation и т.д. Четвертое издание полностью обновлено в соответствии со спецификацией платформы .NET Framework 4.5, а также среды Visual Studio 2012 и C# 5.0."},
                new Product
                {
                    ProductId = 488,
                    CategoryId = 1,
                    BrandId = 2,
                    AuthorId = 2,
                    Name = "Программирование на C# для начинающих. Особенности языка",
                    Price = 924,
                    ImageLink = "https://cdn1.ozone.ru/multimedia/1026291302.jpg",
                    Description = "Вторая часть самоучителя по C#, написанного известным российским автором учебников по программированию Алексеем Васильевым. Она посвященная особенностям языка C# и его практическому применению. Из этой книги вы узнаете, какие основные структурные единицы языка существуют, научитесь писать программы, используя все основные методы и интерфейсы, и овладеете одним из самых востребованных и популярных языков семейства C."
                },
                new Product
                {
                    ProductId = 477,
                    CategoryId = 1,
                    BrandId = 3,
                    AuthorId = 3,
                    Name = "C# для профессионалов. Тонкости программирования",
                    Price = 2484,
                    ImageLink = "https://cdn1.ozone.ru/multimedia/1026732931.jpg",
                    Description = "Книга «C# для профессионалов: тонкости программирования» (C# in Depth) является обновлением предыдущего издания, ставшего бестселлером, с целью раскрытия новых средств языка C# 5, включая решение проблем, которые связаны с написанием сопровождаемого асинхронного кода. Она предлагает уникальные сведения о сложных областях и темных закоулках языка, которые может предоставить только эксперт Джон Скит."},
                new Product
                { 
                    ProductId = 439,
                    CategoryId = 1,
                    BrandId = 4,
                    AuthorId = 4,
                    Name = "Библия C#. 5-е изд., перераб. и доп",
                    Price = 770,
                    ImageLink = "https://cdn1.ozone.ru/s3/multimedia-z/6129084299.jpg",
                    Description = "Книга посвящена программированию на языке С# для платформы Microsoft .NET, начиная с основ языка и разработки программ для работы в режиме командной строки и заканчивая созданием современных веб-приложений. Материал сопровождается большим количеством практических примеров. Подробно описывается логика выполнения каждого участка программы. Уделено внимание вопросам повторного использования кода. В пятом издании примеры переписаны с учетом современной платформы .NET 5, а вместо прикладных приложений упор делается на веб-приложения. На сайте издательства находятся коды программ, дополнительная справочная информация и копия базы данных для выполнения примеров из книги."
                },
            };
        }

        public void AddProduct(Product product)
        {
            if (products.Any(x => x.Name.Equals(product.Name, StringComparison.CurrentCultureIgnoreCase))) return;

            if (products != null && products.Count > 0)
            {
                var maxId = products.Max(x => x.CategoryId);
                product.CategoryId = maxId + 1;
            }
            else
            {
                product.CategoryId = 1;
            }
            products.Add(product);
        }

        public void DeleteProduct(int productId)
        {
            var productToDelete = GetProduct(productId);
            if (productToDelete != null)
            {
                products.Remove(productToDelete);
            }
        }

        public Product GetProduct(int id)
        {
            return products.FirstOrDefault(x => x.ProductId == id);
        }

        public IEnumerable<Product> GetProducts(string filter = null)
        {
            if (string.IsNullOrWhiteSpace(filter)) return products;

            return products.Where(x => x.Name.ToLower().Contains(filter.ToLower()));
        }

        public void UpdateProduct(Product product)
        {
            var productToUpdate = GetProduct(product.ProductId);
            if (productToUpdate != null)
            {
                productToUpdate.Name = product.Name;
                productToUpdate.ImageLink = product.ImageLink;
                productToUpdate.Price = product.Price;
                productToUpdate.Description = product.Description;
                productToUpdate.AuthorId = product.AuthorId;
                productToUpdate.BrandId = product.BrandId;
                productToUpdate.CategoryId = product.CategoryId;
            }
        }
    }
}
