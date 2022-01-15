using eShop.CoreBusiness.Models;
using Microsoft.EntityFrameworkCore;
using System;


namespace eShop.DataStore.SQL.EF
{
    public class eShopContext : DbContext
    {
        public eShopContext(DbContextOptions options) : base(options) 
        {
        }

        public DbSet<Product> Product { get; set; }

        public DbSet<Order> Order { get; set; }

        public DbSet<OrderLineItem> OrderLineItem { get; set; }

        public DbSet<Brand> Brand { get; set; }

        public DbSet<Author> Author { get; set; }

        public DbSet<Category> Category { get; set; }

        public DbSet<AuthorForProduct> AuthorForProduct { get; set; }

        public DbSet<BrandForProduct> BrandForProduct { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Product>()
                        .HasMany(c => c.AuthorForProducts)
                        .WithOne(p => p.Product)
                        .HasForeignKey(p => p.ProductId);

            modelBuilder.Entity<Product>()
                        .HasMany(c => c.BrandForProducts)
                        .WithOne(p => p.Product)
                        .HasForeignKey(p => p.ProductId);

            modelBuilder.Entity<Category>()
                        .HasMany(c => c.Products)
                        .WithOne(p => p.Category)
                        .HasForeignKey(p => p.CategoryId);

            modelBuilder.Entity<Brand>()
                        .HasMany(c => c.BrandForProducts)
                        .WithOne(p => p.Brand)
                        .HasForeignKey(p => p.BrandId);

            modelBuilder.Entity<Author>()
                        .HasMany(c => c.AuthorForProducts)
                        .WithOne(p => p.Author)
                        .HasForeignKey(p => p.AuthorId);

            modelBuilder.Entity<AuthorForProduct>().HasData(
                new AuthorForProduct { AuthorForProductId = 1, AuthorId = 1, ProductId = 1},
                new AuthorForProduct { AuthorForProductId = 2, AuthorId = 2, ProductId = 2},
                new AuthorForProduct { AuthorForProductId = 3, AuthorId = 3, ProductId = 3},
                new AuthorForProduct { AuthorForProductId = 4, AuthorId = 4, ProductId = 4});

            modelBuilder.Entity<BrandForProduct>().HasData(
                new BrandForProduct { BrandForProductId = 1, BrandId = 1, ProductId = 1 },
                new BrandForProduct { BrandForProductId = 2, BrandId = 2, ProductId = 2 },
                new BrandForProduct { BrandForProductId = 3, BrandId = 3, ProductId = 3 },
                new BrandForProduct { BrandForProductId = 4, BrandId = 4, ProductId = 4 });

            modelBuilder.Entity<Author>().HasData(
                new Author { AuthorId = 1, FirstName = "Джеффри", LastName = "Рихтер" },
                new Author { AuthorId = 2, FirstName = "Алексей", LastName = "Васильев", SecondName = "Николаевич" },
                new Author { AuthorId = 3, FirstName = "Джон", LastName = "Скит" },
                new Author { AuthorId = 4, FirstName = "Михаил", LastName = "Фленов", SecondName = "Евгеньевич" });

            modelBuilder.Entity<Brand>().HasData(
                new Brand { BrandId = 1, Name = "БХВ-Петербург", Description = "тест" },
                new Brand { BrandId = 2, Name = "Вильямс", Description = "тест" },
                new Brand { BrandId = 3, Name = "Бомбора", Description = "тест" },
                new Brand { BrandId = 4, Name = "Прогресс книга", Description = "тест" });


            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Нон-фикшен", Description = "Техническая литература для изучения программирования и не только" },
                new Category { CategoryId = 2, Name = "Художественная литература", Description = "Вид искусства, использующий в качестве единственного материала слова и конструкции естественного языка." });

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ProductId = 1,
                    BrandId = 1,
                    CategoryId = 1,
                    AuthorId = 1,
                    Name = "CLR via C#. Программирование на платформе Microsoft .NET Framework 4.5 на языке C#. 4-е изд.",
                    Price = 1825,
                    ImageLink = "https://cdn1.ozone.ru/s3/multimedia-i/6170125470.jpg",
                    Description = "Эта книга, выходящая в четвертом издании и уже ставшая классическим учебником по программированию, подробно описывает внутреннее устройство и функционирование общеязыковой исполняющей среды (CLR) Microsoft .NET Framework версии 4.5. Написанная признанным экспертом в области программирования Джеффри Рихтером, много лет являющимся консультантом команды разработчиков .NET Framework компании Microsoft, книга научит вас создавать по-настоящему надежные приложения любого вида, в том числе с использованием Microsoft Silverlight, ASP.NET, Windows Presentation Foundation и т.д. Четвертое издание полностью обновлено в соответствии со спецификацией платформы .NET Framework 4.5, а также среды Visual Studio 2012 и C# 5.0."
                },
                new Product
                {
                    ProductId = 2,
                    BrandId = 2,
                    CategoryId = 1,
                    AuthorId = 2,
                    Name = "Программирование на C# для начинающих. Особенности языка",
                    Price = 924,
                    ImageLink = "https://cdn1.ozone.ru/multimedia/1026291302.jpg",
                    Description = "Вторая часть самоучителя по C#, написанного известным российским автором учебников по программированию Алексеем Васильевым. Она посвященная особенностям языка C# и его практическому применению. Из этой книги вы узнаете, какие основные структурные единицы языка существуют, научитесь писать программы, используя все основные методы и интерфейсы, и овладеете одним из самых востребованных и популярных языков семейства C."
                },
                new Product
                {
                    ProductId = 3,
                    BrandId = 3,
                    CategoryId = 1,
                    AuthorId = 3,
                    Name = "C# для профессионалов. Тонкости программирования",
                    Price = 2484,
                    ImageLink = "https://cdn1.ozone.ru/multimedia/1026732931.jpg",
                    Description = "Книга «C# для профессионалов: тонкости программирования» (C# in Depth) является обновлением предыдущего издания, ставшего бестселлером, с целью раскрытия новых средств языка C# 5, включая решение проблем, которые связаны с написанием сопровождаемого асинхронного кода. Она предлагает уникальные сведения о сложных областях и темных закоулках языка, которые может предоставить только эксперт Джон Скит."
                },
                new Product
                {
                    ProductId = 4,
                    BrandId = 4,
                    CategoryId = 1,
                    AuthorId = 4,
                    Name = "Библия C#. 5-е изд., перераб. и доп",
                    Price = 770,
                    ImageLink = "https://cdn1.ozone.ru/s3/multimedia-z/6129084299.jpg",
                    Description = "Книга посвящена программированию на языке С# для платформы Microsoft .NET, начиная с основ языка и разработки программ для работы в режиме командной строки и заканчивая созданием современных веб-приложений. Материал сопровождается большим количеством практических примеров. Подробно описывается логика выполнения каждого участка программы. Уделено внимание вопросам повторного использования кода. В пятом издании примеры переписаны с учетом современной платформы .NET 5, а вместо прикладных приложений упор делается на веб-приложения. На сайте издательства находятся коды программ, дополнительная справочная информация и копия базы данных для выполнения примеров из книги."
                });
        }
    }
}
