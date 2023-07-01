using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CongresoServer.Migrations
{
    public partial class ContraseñaEnParticipante : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Contraseña",
                table: "Participante",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Contraseña",
                table: "Participante");
        }
    }
}
