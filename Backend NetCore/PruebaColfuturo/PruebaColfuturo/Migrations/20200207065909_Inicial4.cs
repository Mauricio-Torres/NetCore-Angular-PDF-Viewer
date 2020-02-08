using Microsoft.EntityFrameworkCore.Migrations;

namespace PruebaColfuturo.Migrations
{
    public partial class Inicial4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartaGenerada_TipoCarta_TipoCartasId",
                table: "CartaGenerada");

            migrationBuilder.DropIndex(
                name: "IX_CartaGenerada_TipoCartasId",
                table: "CartaGenerada");

            migrationBuilder.DropColumn(
                name: "TipoCartasId",
                table: "CartaGenerada");

            migrationBuilder.AddColumn<int>(
                name: "IdiomasId",
                table: "TipoCarta",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TipoCarta_IdiomasId",
                table: "TipoCarta",
                column: "IdiomasId");

            migrationBuilder.AddForeignKey(
                name: "FK_TipoCarta_Idioma_IdiomasId",
                table: "TipoCarta",
                column: "IdiomasId",
                principalTable: "Idioma",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TipoCarta_Idioma_IdiomasId",
                table: "TipoCarta");

            migrationBuilder.DropIndex(
                name: "IX_TipoCarta_IdiomasId",
                table: "TipoCarta");

            migrationBuilder.DropColumn(
                name: "IdiomasId",
                table: "TipoCarta");

            migrationBuilder.AddColumn<int>(
                name: "TipoCartasId",
                table: "CartaGenerada",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CartaGenerada_TipoCartasId",
                table: "CartaGenerada",
                column: "TipoCartasId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartaGenerada_TipoCarta_TipoCartasId",
                table: "CartaGenerada",
                column: "TipoCartasId",
                principalTable: "TipoCarta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
