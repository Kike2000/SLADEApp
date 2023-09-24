using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CongresoServer.Migrations
{
    public partial class DesasociarEvento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Desasociar",
                table: "Evento",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Desasociar",
                table: "Evento");
        }
    }
}
