﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using eShop.DataStore.SQL.EF;

namespace eShop.DataStore.SQL.EF.Migrations
{
    [DbContext(typeof(eShopContext))]
    partial class eShopContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("eShop.CoreBusiness.Models.Author", b =>
                {
                    b.Property<int>("AuthorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecondName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AuthorId");

                    b.ToTable("Author");

                    b.HasData(
                        new
                        {
                            AuthorId = 1,
                            FirstName = "Джеффри",
                            LastName = "Рихтер"
                        },
                        new
                        {
                            AuthorId = 2,
                            FirstName = "Алексей",
                            LastName = "Васильев",
                            SecondName = "Николаевич"
                        },
                        new
                        {
                            AuthorId = 3,
                            FirstName = "Джон",
                            LastName = "Скит"
                        },
                        new
                        {
                            AuthorId = 4,
                            FirstName = "Михаил",
                            LastName = "Фленов",
                            SecondName = "Евгеньевич"
                        });
                });

            modelBuilder.Entity("eShop.CoreBusiness.Models.AuthorForProduct", b =>
                {
                    b.Property<int>("AuthorForProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("AuthorForProductId");

                    b.HasIndex("AuthorId");

                    b.HasIndex("ProductId");

                    b.ToTable("AuthorForProduct");

                    b.HasData(
                        new
                        {
                            AuthorForProductId = 1,
                            AuthorId = 1,
                            ProductId = 1
                        },
                        new
                        {
                            AuthorForProductId = 2,
                            AuthorId = 2,
                            ProductId = 2
                        },
                        new
                        {
                            AuthorForProductId = 3,
                            AuthorId = 3,
                            ProductId = 3
                        },
                        new
                        {
                            AuthorForProductId = 4,
                            AuthorId = 4,
                            ProductId = 4
                        });
                });

            modelBuilder.Entity("eShop.CoreBusiness.Models.Brand", b =>
                {
                    b.Property<int>("BrandId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BrandId");

                    b.ToTable("Brand");

                    b.HasData(
                        new
                        {
                            BrandId = 1,
                            Description = "тест",
                            Name = "БХВ-Петербург"
                        },
                        new
                        {
                            BrandId = 2,
                            Description = "тест",
                            Name = "Вильямс"
                        },
                        new
                        {
                            BrandId = 3,
                            Description = "тест",
                            Name = "Бомбора"
                        },
                        new
                        {
                            BrandId = 4,
                            Description = "тест",
                            Name = "Прогресс книга"
                        });
                });

            modelBuilder.Entity("eShop.CoreBusiness.Models.BrandForProduct", b =>
                {
                    b.Property<int>("BrandForProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("BrandForProductId");

                    b.HasIndex("BrandId");

                    b.HasIndex("ProductId");

                    b.ToTable("BrandForProduct");

                    b.HasData(
                        new
                        {
                            BrandForProductId = 1,
                            BrandId = 1,
                            ProductId = 1
                        },
                        new
                        {
                            BrandForProductId = 2,
                            BrandId = 2,
                            ProductId = 2
                        },
                        new
                        {
                            BrandForProductId = 3,
                            BrandId = 3,
                            ProductId = 3
                        },
                        new
                        {
                            BrandForProductId = 4,
                            BrandId = 4,
                            ProductId = 4
                        });
                });

            modelBuilder.Entity("eShop.CoreBusiness.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Category");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            Description = "Техническая литература для изучения программирования и не только",
                            Name = "Нон-фикшен"
                        },
                        new
                        {
                            CategoryId = 2,
                            Description = "Вид искусства, использующий в качестве единственного материала слова и конструкции естественного языка.",
                            Name = "Художественная литература"
                        });
                });

            modelBuilder.Entity("eShop.CoreBusiness.Models.Order", b =>
                {
                    b.Property<int?>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AdminUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerCity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerCountry")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerStateProvince")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DatePlaced")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateProcessed")
                        .HasColumnType("datetime2");

                    b.Property<string>("UniqueId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("OrderId");

                    b.HasIndex("UserId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("eShop.CoreBusiness.Models.OrderLineItem", b =>
                {
                    b.Property<int>("OrderineItem")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("OrderineItem");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderLineItem");
                });

            modelBuilder.Entity("eShop.CoreBusiness.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Product");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            AuthorId = 1,
                            BrandId = 1,
                            CategoryId = 1,
                            Description = "Эта книга, выходящая в четвертом издании и уже ставшая классическим учебником по программированию, подробно описывает внутреннее устройство и функционирование общеязыковой исполняющей среды (CLR) Microsoft .NET Framework версии 4.5. Написанная признанным экспертом в области программирования Джеффри Рихтером, много лет являющимся консультантом команды разработчиков .NET Framework компании Microsoft, книга научит вас создавать по-настоящему надежные приложения любого вида, в том числе с использованием Microsoft Silverlight, ASP.NET, Windows Presentation Foundation и т.д. Четвертое издание полностью обновлено в соответствии со спецификацией платформы .NET Framework 4.5, а также среды Visual Studio 2012 и C# 5.0.",
                            ImageLink = "https://cdn1.ozone.ru/s3/multimedia-i/6170125470.jpg",
                            Name = "CLR via C#. Программирование на платформе Microsoft .NET Framework 4.5 на языке C#. 4-е изд.",
                            Price = 1825.0
                        },
                        new
                        {
                            ProductId = 2,
                            AuthorId = 2,
                            BrandId = 2,
                            CategoryId = 1,
                            Description = "Вторая часть самоучителя по C#, написанного известным российским автором учебников по программированию Алексеем Васильевым. Она посвященная особенностям языка C# и его практическому применению. Из этой книги вы узнаете, какие основные структурные единицы языка существуют, научитесь писать программы, используя все основные методы и интерфейсы, и овладеете одним из самых востребованных и популярных языков семейства C.",
                            ImageLink = "https://cdn1.ozone.ru/multimedia/1026291302.jpg",
                            Name = "Программирование на C# для начинающих. Особенности языка",
                            Price = 924.0
                        },
                        new
                        {
                            ProductId = 3,
                            AuthorId = 3,
                            BrandId = 3,
                            CategoryId = 1,
                            Description = "Книга «C# для профессионалов: тонкости программирования» (C# in Depth) является обновлением предыдущего издания, ставшего бестселлером, с целью раскрытия новых средств языка C# 5, включая решение проблем, которые связаны с написанием сопровождаемого асинхронного кода. Она предлагает уникальные сведения о сложных областях и темных закоулках языка, которые может предоставить только эксперт Джон Скит.",
                            ImageLink = "https://cdn1.ozone.ru/multimedia/1026732931.jpg",
                            Name = "C# для профессионалов. Тонкости программирования",
                            Price = 2484.0
                        },
                        new
                        {
                            ProductId = 4,
                            AuthorId = 4,
                            BrandId = 4,
                            CategoryId = 1,
                            Description = "Книга посвящена программированию на языке С# для платформы Microsoft .NET, начиная с основ языка и разработки программ для работы в режиме командной строки и заканчивая созданием современных веб-приложений. Материал сопровождается большим количеством практических примеров. Подробно описывается логика выполнения каждого участка программы. Уделено внимание вопросам повторного использования кода. В пятом издании примеры переписаны с учетом современной платформы .NET 5, а вместо прикладных приложений упор делается на веб-приложения. На сайте издательства находятся коды программ, дополнительная справочная информация и копия базы данных для выполнения примеров из книги.",
                            ImageLink = "https://cdn1.ozone.ru/s3/multimedia-z/6129084299.jpg",
                            Name = "Библия C#. 5-е изд., перераб. и доп",
                            Price = 770.0
                        });
                });

            modelBuilder.Entity("eShop.CoreBusiness.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("eShop.CoreBusiness.Models.AuthorForProduct", b =>
                {
                    b.HasOne("eShop.CoreBusiness.Models.Author", "Author")
                        .WithMany("AuthorForProducts")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eShop.CoreBusiness.Models.Product", "Product")
                        .WithMany("AuthorForProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("eShop.CoreBusiness.Models.BrandForProduct", b =>
                {
                    b.HasOne("eShop.CoreBusiness.Models.Brand", "Brand")
                        .WithMany("BrandForProducts")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eShop.CoreBusiness.Models.Product", "Product")
                        .WithMany("BrandForProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("eShop.CoreBusiness.Models.Order", b =>
                {
                    b.HasOne("eShop.CoreBusiness.Models.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("eShop.CoreBusiness.Models.OrderLineItem", b =>
                {
                    b.HasOne("eShop.CoreBusiness.Models.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId");

                    b.HasOne("eShop.CoreBusiness.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("eShop.CoreBusiness.Models.Product", b =>
                {
                    b.HasOne("eShop.CoreBusiness.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
