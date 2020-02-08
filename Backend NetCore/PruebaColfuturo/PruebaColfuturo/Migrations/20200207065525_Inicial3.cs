using Microsoft.EntityFrameworkCore.Migrations;

namespace PruebaColfuturo.Migrations
{
    public partial class Inicial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdCarta",
                table: "Usuario");

            migrationBuilder.CreateTable(
                name: "Idioma",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Idioma", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoCarta",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoCarta", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CartaGenerada",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Apellido = table.Column<string>(nullable: true),
                    Titulo = table.Column<string>(nullable: true),
                    Cargo = table.Column<string>(nullable: true),
                    Organizacion = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(nullable: true),
                    Ciudad = table.Column<string>(nullable: true),
                    Pais = table.Column<int>(nullable: false),
                    UsuariosId = table.Column<int>(nullable: true),
                    TipoCartasId = table.Column<int>(nullable: true),
                    IdiomasId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartaGenerada", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartaGenerada_Idioma_IdiomasId",
                        column: x => x.IdiomasId,
                        principalTable: "Idioma",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CartaGenerada_TipoCarta_TipoCartasId",
                        column: x => x.TipoCartasId,
                        principalTable: "TipoCarta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CartaGenerada_Usuario_UsuariosId",
                        column: x => x.UsuariosId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartaGenerada_IdiomasId",
                table: "CartaGenerada",
                column: "IdiomasId");

            migrationBuilder.CreateIndex(
                name: "IX_CartaGenerada_TipoCartasId",
                table: "CartaGenerada",
                column: "TipoCartasId");

            migrationBuilder.CreateIndex(
                name: "IX_CartaGenerada_UsuariosId",
                table: "CartaGenerada",
                column: "UsuariosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartaGenerada");

            migrationBuilder.DropTable(
                name: "Idioma");

            migrationBuilder.DropTable(
                name: "TipoCarta");

            migrationBuilder.AddColumn<int>(
                name: "IdCarta",
                table: "Usuario",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
