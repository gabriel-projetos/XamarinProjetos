using Microsoft.EntityFrameworkCore.Migrations;

namespace GerenciadorNotas.Repositorio.Migrations
{
    public partial class adicaodocampora : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RA",
                table: "Alunos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RA",
                table: "Alunos");
        }
    }
}
