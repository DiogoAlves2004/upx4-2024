using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.UPX4.Data.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "pontodeacessibilidade",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    descricaopontodeacessibilidade = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    cordx = table.Column<double>(type: "double precision", nullable: false),
                    cordy = table.Column<double>(type: "double precision", nullable: false),
                    idusuariocriador = table.Column<string>(type: "text", nullable: false),
                    idicone = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pontodeacessibilidade", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pontodeacessibilidade");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
