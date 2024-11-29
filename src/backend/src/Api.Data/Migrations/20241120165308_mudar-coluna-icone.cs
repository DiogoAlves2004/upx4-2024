using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.UPX4.Data.Migrations
{
    /// <inheritdoc />
    public partial class mudarcolunaicone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "idicone",
                table: "pontodeacessibilidade",
                newName: "icone");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "icone",
                table: "pontodeacessibilidade",
                newName: "idicone");
        }
    }
}
