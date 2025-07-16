using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace books.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Караганда" },
                    { 2, "Астана" },
                    { 3, "Алмата" },
                    { 4, "Темиртау" },
                    { 5, "Шымкент" }
                });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "Id", "CityId", "FirstName", "LastName", "MiddleName", "Note" },
                values: new object[,]
                {
                    { 1, 1, "Иван", "Иванов", "Иванович", "Сидел 2 года" },
                    { 2, 2, "Петр", "Петров", "Петрович", "ну просто Петя" },
                    { 3, 3, "Сергей", "Сергеев", "Сергеевич", "четкий пацан" },
                    { 4, 4, "Дмитрий", "Дмитриев", "Дмитриевич", "спортсмен" },
                    { 5, 5, "Андрей", "Андреев", "Андреевич", "в законе" }
                });

            migrationBuilder.InsertData(
                table: "Phones",
                columns: new[] { "Id", "IsBankLinked", "PersonId", "PhoneNumber", "PhoneType" },
                values: new object[,]
                {
                    { 1, true, 1, "+77978972679", "сотовый" },
                    { 2, false, 2, "+77777777777", "сотовый" },
                    { 3, true, 3, "+77765672456", "сотовый" },
                    { 4, false, 4, "+77778976655", "сотовый" },
                    { 5, true, 5, "+77770950095", "сотовый" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
