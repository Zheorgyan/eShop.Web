using Microsoft.EntityFrameworkCore.Migrations;

namespace eShop.DataStore.SQL.EF.Migrations
{
    public partial class _02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 439);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 477);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 488);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 495);

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductId", "AuthorId", "BrandId", "CategoryId", "Description", "ImageLink", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, 1, 1, "Эта книга, выходящая в четвертом издании и уже ставшая классическим учебником по программированию, подробно описывает внутреннее устройство и функционирование общеязыковой исполняющей среды (CLR) Microsoft .NET Framework версии 4.5. Написанная признанным экспертом в области программирования Джеффри Рихтером, много лет являющимся консультантом команды разработчиков .NET Framework компании Microsoft, книга научит вас создавать по-настоящему надежные приложения любого вида, в том числе с использованием Microsoft Silverlight, ASP.NET, Windows Presentation Foundation и т.д. Четвертое издание полностью обновлено в соответствии со спецификацией платформы .NET Framework 4.5, а также среды Visual Studio 2012 и C# 5.0.", "https://cdn1.ozone.ru/s3/multimedia-i/6170125470.jpg", "CLR via C#. Программирование на платформе Microsoft .NET Framework 4.5 на языке C#. 4-е изд.", 1825.0 },
                    { 2, 2, 2, 1, "Вторая часть самоучителя по C#, написанного известным российским автором учебников по программированию Алексеем Васильевым. Она посвященная особенностям языка C# и его практическому применению. Из этой книги вы узнаете, какие основные структурные единицы языка существуют, научитесь писать программы, используя все основные методы и интерфейсы, и овладеете одним из самых востребованных и популярных языков семейства C.", "https://cdn1.ozone.ru/multimedia/1026291302.jpg", "Программирование на C# для начинающих. Особенности языка", 924.0 },
                    { 3, 3, 3, 1, "Книга «C# для профессионалов: тонкости программирования» (C# in Depth) является обновлением предыдущего издания, ставшего бестселлером, с целью раскрытия новых средств языка C# 5, включая решение проблем, которые связаны с написанием сопровождаемого асинхронного кода. Она предлагает уникальные сведения о сложных областях и темных закоулках языка, которые может предоставить только эксперт Джон Скит.", "https://cdn1.ozone.ru/multimedia/1026732931.jpg", "C# для профессионалов. Тонкости программирования", 2484.0 },
                    { 4, 4, 4, 1, "Книга посвящена программированию на языке С# для платформы Microsoft .NET, начиная с основ языка и разработки программ для работы в режиме командной строки и заканчивая созданием современных веб-приложений. Материал сопровождается большим количеством практических примеров. Подробно описывается логика выполнения каждого участка программы. Уделено внимание вопросам повторного использования кода. В пятом издании примеры переписаны с учетом современной платформы .NET 5, а вместо прикладных приложений упор делается на веб-приложения. На сайте издательства находятся коды программ, дополнительная справочная информация и копия базы данных для выполнения примеров из книги.", "https://cdn1.ozone.ru/s3/multimedia-z/6129084299.jpg", "Библия C#. 5-е изд., перераб. и доп", 770.0 }
                });

            migrationBuilder.AddColumn<string>(name: "AdditionalText", table: "Order", nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AuthorForProduct",
                keyColumn: "AuthorForProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AuthorForProduct",
                keyColumn: "AuthorForProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AuthorForProduct",
                keyColumn: "AuthorForProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AuthorForProduct",
                keyColumn: "AuthorForProductId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "BrandForProduct",
                keyColumn: "BrandForProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BrandForProduct",
                keyColumn: "BrandForProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BrandForProduct",
                keyColumn: "BrandForProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BrandForProduct",
                keyColumn: "BrandForProductId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 4);

            migrationBuilder.InsertData(
                table: "AuthorForProduct",
                columns: new[] { "AuthorForProductId", "AuthorId", "ProductId" },
                values: new object[,]
                {
                    { 4, 4, 4 },
                    { 3, 3, 3 },
                    { 2, 2, 2 },
                    { 1, 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "BrandForProduct",
                columns: new[] { "BrandForProductId", "BrandId", "ProductId" },
                values: new object[,]
                {
                    { 4, 4, 4 },
                    { 3, 3, 3 },
                    { 2, 2, 2 },
                    { 1, 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductId", "AuthorId", "BrandId", "CategoryId", "Description", "ImageLink", "Name", "Price" },
                values: new object[,]
                {
                    { 495, 1, 1, 1, "Эта книга, выходящая в четвертом издании и уже ставшая классическим учебником по программированию, подробно описывает внутреннее устройство и функционирование общеязыковой исполняющей среды (CLR) Microsoft .NET Framework версии 4.5. Написанная признанным экспертом в области программирования Джеффри Рихтером, много лет являющимся консультантом команды разработчиков .NET Framework компании Microsoft, книга научит вас создавать по-настоящему надежные приложения любого вида, в том числе с использованием Microsoft Silverlight, ASP.NET, Windows Presentation Foundation и т.д. Четвертое издание полностью обновлено в соответствии со спецификацией платформы .NET Framework 4.5, а также среды Visual Studio 2012 и C# 5.0.", "https://cdn1.ozone.ru/s3/multimedia-i/6170125470.jpg", "CLR via C#. Программирование на платформе Microsoft .NET Framework 4.5 на языке C#. 4-е изд.", 1825.0 },
                    { 488, 2, 2, 1, "Вторая часть самоучителя по C#, написанного известным российским автором учебников по программированию Алексеем Васильевым. Она посвященная особенностям языка C# и его практическому применению. Из этой книги вы узнаете, какие основные структурные единицы языка существуют, научитесь писать программы, используя все основные методы и интерфейсы, и овладеете одним из самых востребованных и популярных языков семейства C.", "https://cdn1.ozone.ru/multimedia/1026291302.jpg", "Программирование на C# для начинающих. Особенности языка", 924.0 },
                    { 477, 3, 3, 1, "Книга «C# для профессионалов: тонкости программирования» (C# in Depth) является обновлением предыдущего издания, ставшего бестселлером, с целью раскрытия новых средств языка C# 5, включая решение проблем, которые связаны с написанием сопровождаемого асинхронного кода. Она предлагает уникальные сведения о сложных областях и темных закоулках языка, которые может предоставить только эксперт Джон Скит.", "https://cdn1.ozone.ru/multimedia/1026732931.jpg", "C# для профессионалов. Тонкости программирования", 2484.0 },
                    { 439, 4, 4, 1, "Книга посвящена программированию на языке С# для платформы Microsoft .NET, начиная с основ языка и разработки программ для работы в режиме командной строки и заканчивая созданием современных веб-приложений. Материал сопровождается большим количеством практических примеров. Подробно описывается логика выполнения каждого участка программы. Уделено внимание вопросам повторного использования кода. В пятом издании примеры переписаны с учетом современной платформы .NET 5, а вместо прикладных приложений упор делается на веб-приложения. На сайте издательства находятся коды программ, дополнительная справочная информация и копия базы данных для выполнения примеров из книги.", "https://cdn1.ozone.ru/s3/multimedia-z/6129084299.jpg", "Библия C#. 5-е изд., перераб. и доп", 770.0 }
                });

                migrationBuilder.DropColumn(name: "AdditionalText", table: "Order");
        }
    }
}
