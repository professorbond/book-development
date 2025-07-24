using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace books.Migrations
{
    /// <inheritdoc />
    public partial class AddMorePhones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Phones",
                columns: new[] { "Id", "IsBankLinked", "PersonId", "PhoneNumber", "PhoneType" },
                values: new object[,]
                {
                    { 6, false, 1, "+77001112233", "домашний" },
                    { 7, true, 2, "+77005556677", "рабочий" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 7);
        }
    }
}
