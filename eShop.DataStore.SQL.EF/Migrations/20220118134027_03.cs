using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eShop.DataStore.SQL.EF.Migrations
{
    public partial class _03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdditionalText",
                table: "Order",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdditionalText",
                table: "Order");
        }
    }
}
