using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShop.DataStore.SQL.Dapper
{
    [Migration(202211010001)]
    public class InitialTables_202211010001 : Migration
    {
        public override void Down()
        {
            Delete.Table("Product");
            Delete.Table("Brand");
            Delete.Table("Category");
            Delete.Table("Order");
            Delete.Table("OrderLineItem");
        }

        public override void Up()
        {
            Create.Table("Product")
                .WithColumn("ProductId").AsInt32().NotNullable().PrimaryKey()
                .WithColumn("BrandId").AsInt32().NotNullable().ForeignKey("Brand", "BrandId")
                .WithColumn("CategoryId").AsInt32().NotNullable().ForeignKey("Category", "CategoryId")
                .WithColumn("Name").AsString(150).NotNullable()
                .WithColumn("Price").AsDecimal().NotNullable()
                .WithColumn("ImageLink").AsString(200).NotNullable()
                .WithColumn("Desctiprion").AsString(500).NotNullable()
                .WithColumn("Author").AsString(100).NotNullable();

        }
    }
}
