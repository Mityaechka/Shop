using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop.Api.Migrations
{
    public partial class AddSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Files",
                columns: new[] { "Id", "Path" },
                values: new object[,]
                {
                    { 1, "/images/glasses.jpg" },
                    { 2, "/images/headphones.jpg" },
                    { 3, "/images/pepsi.jpg" },
                    { 4, "/images/watch.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ImageId", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, "Очки", 1000m },
                    { 2, 2, "Наушники", 3500m },
                    { 3, 3, "Pepsi-Cole", 350m },
                    { 4, 4, "Очки", 5000m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
