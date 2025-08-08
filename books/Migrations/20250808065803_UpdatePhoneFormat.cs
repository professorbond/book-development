using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace books.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePhoneFormat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 1,
                column: "PhoneNumber",
                value: "+7 (797) 897 2679");

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 2,
                column: "PhoneNumber",
                value: "+7 (777) 777 7777");

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 3,
                column: "PhoneNumber",
                value: "+7 (776) 567 2456");

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 4,
                column: "PhoneNumber",
                value: "+7 (777) 897 6655");

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 5,
                column: "PhoneNumber",
                value: "+7 (777) 095 0095");

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 6,
                column: "PhoneNumber",
                value: "+7 (700) 111 2233");

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 7,
                column: "PhoneNumber",
                value: "+7 (700) 555 6677");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 1,
                column: "PhoneNumber",
                value: "+77978972679");

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 2,
                column: "PhoneNumber",
                value: "+77777777777");

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 3,
                column: "PhoneNumber",
                value: "+77765672456");

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 4,
                column: "PhoneNumber",
                value: "+77778976655");

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 5,
                column: "PhoneNumber",
                value: "+77770950095");

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 6,
                column: "PhoneNumber",
                value: "+77001112233");

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 7,
                column: "PhoneNumber",
                value: "+77005556677");
        }
    }
}
