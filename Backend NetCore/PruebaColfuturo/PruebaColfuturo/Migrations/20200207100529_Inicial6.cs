using Microsoft.EntityFrameworkCore.Migrations;

namespace PruebaColfuturo.Migrations
{
    public partial class Inicial6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Pais",
                table: "CartaGenerada",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "namePdf",
                table: "CartaGenerada",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "urlPdf",
                table: "CartaGenerada",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "namePdf",
                table: "CartaGenerada");

            migrationBuilder.DropColumn(
                name: "urlPdf",
                table: "CartaGenerada");

            migrationBuilder.AlterColumn<int>(
                name: "Pais",
                table: "CartaGenerada",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
