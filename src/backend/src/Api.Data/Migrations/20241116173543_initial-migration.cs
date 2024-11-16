using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.UPX4.Data.Migrations
{
    /// <inheritdoc />
    public partial class initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f952577b-291f-4873-9485-73fa01ab7ab8"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreateAt", "Email", "Name", "Password", "UpdatedAt" },
                values: new object[] { new Guid("6cd0fcd9-454b-46db-b9e3-ef39e4a872db"), new DateTime(2024, 11, 16, 14, 35, 42, 31, DateTimeKind.Local).AddTicks(7022), "adm@mail.com", "Adm", "adm123", new DateTime(2024, 11, 16, 14, 35, 42, 36, DateTimeKind.Local).AddTicks(4202) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6cd0fcd9-454b-46db-b9e3-ef39e4a872db"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreateAt", "Email", "Name", "Password", "UpdatedAt" },
                values: new object[] { new Guid("f952577b-291f-4873-9485-73fa01ab7ab8"), new DateTime(2024, 11, 16, 14, 31, 32, 922, DateTimeKind.Local).AddTicks(726), "adm@mail.com", "Adm", "adm123", new DateTime(2024, 11, 16, 14, 31, 32, 925, DateTimeKind.Local).AddTicks(5895) });
        }
    }
}
