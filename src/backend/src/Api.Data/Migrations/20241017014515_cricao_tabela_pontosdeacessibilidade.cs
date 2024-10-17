using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class cricao_tabela_pontosdeacessibilidade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreateAt", "Email", "Name", "Password", "UpdatedAt" },
                values: new object[] { new Guid("f9469786-3477-40fd-91a0-513831550931"), new DateTime(2024, 10, 16, 22, 45, 15, 195, DateTimeKind.Local).AddTicks(342), "adm@mail.com", "Adm", "adm123", new DateTime(2024, 10, 16, 22, 45, 15, 195, DateTimeKind.Local).AddTicks(362) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f9469786-3477-40fd-91a0-513831550931"));
        }
    }
}
