using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop.Api.Migrations
{
    public partial class AddSeedData2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Files",
                columns: new[] { "Id", "Path" },
                values: new object[,]
                {
                    { 5, "/images/capcake.jpg" },
                    { 6, "/images/cola.jpg" },
                    { 7, "/images/packet.jpg" },
                    { 8, "/images/parfume.jpg" },
                    { 9, "/images/soda.jpg" },
                    { 10, "/images/soda2.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ImageId", "Name", "Price" },
                values: new object[,]
                {
                    { 5, 5, "Кекс", 250m },
                    { 6, 6, "Кола", 300m },
                    { 7, 7, "Кофе", 750m },
                    { 8, 8, "Духи", 15000m },
                    { 9, 9, "Напиток", 500m },
                    { 10, 10, "Candy Dry", 400m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
