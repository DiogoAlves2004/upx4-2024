using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.UPX4.Data.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c3d83c32-4b60-4285-8254-d4f8f1858636"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreateAt", "Email", "Name", "Password", "UpdatedAt" },
                values: new object[] { new Guid("5381c117-ce81-4de6-bed2-4d251a7bf8e8"), new DateTime(2024, 11, 15, 17, 43, 13, 825, DateTimeKind.Local).AddTicks(7380), "adm@mail.com", "Adm", "adm123", new DateTime(2024, 11, 15, 17, 43, 13, 825, DateTimeKind.Local).AddTicks(7398) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5381c117-ce81-4de6-bed2-4d251a7bf8e8"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreateAt", "Email", "Name", "Password", "UpdatedAt" },
                values: new object[] { new Guid("c3d83c32-4b60-4285-8254-d4f8f1858636"), new DateTime(2024, 11, 15, 17, 41, 25, 488, DateTimeKind.Local).AddTicks(8402), "adm@mail.com", "Adm", "adm123", new DateTime(2024, 11, 15, 17, 41, 25, 488, DateTimeKind.Local).AddTicks(8420) });
        }
    }
}
