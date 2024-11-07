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
            migrationBuilder.CreateTable(
                name: "PontosDeAcessibilidade",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    descricaopontodeacessibilidade = table.Column<string>(type: "TEXT", nullable: false),
                    cordx = table.Column<string>(type: "TEXT", nullable: false),
                    cordy = table.Column<string>(type: "TEXT", nullable: false),
                    idusuariocriador = table.Column<string>(type: "TEXT", nullable: false),
                    idicone = table.Column<string>(type: "TEXT", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PontosDeAcessibilidade", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PontosDeAcessibilidade");
        }
    }
}
