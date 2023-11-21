using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication2.Migrations
{
    /// <inheritdoc />
    public partial class addCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0f1096b1-3955-44c0-80de-49e5ad1e5a6b"), "Prywatny" },
                    { new Guid("1fcb30a3-41a1-4f23-bf27-442576775407"), "Służbowy" },
                    { new Guid("330c311a-aeac-40c5-a76b-71361ba01184"), "Inny" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("0f1096b1-3955-44c0-80de-49e5ad1e5a6b"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("1fcb30a3-41a1-4f23-bf27-442576775407"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("330c311a-aeac-40c5-a76b-71361ba01184"));
        }
    }
}
