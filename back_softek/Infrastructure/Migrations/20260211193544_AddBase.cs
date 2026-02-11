using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace back_softek.Migrations
{
    /// <inheritdoc />
    public partial class AddBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autor",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    fechaNac = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ciudadProcedencia = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    correo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autor", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Libro",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titulo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    año = table.Column<int>(type: "int", nullable: false),
                    genero = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    numeroPaginas = table.Column<int>(type: "int", nullable: false),
                    autorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libro", x => x.id);
                    table.ForeignKey(
                        name: "FK_Libro_Autor_autorId",
                        column: x => x.autorId,
                        principalTable: "Autor",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Autor_correo",
                table: "Autor",
                column: "correo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Libro_autorId",
                table: "Libro",
                column: "autorId");

            migrationBuilder.CreateIndex(
                name: "IX_Libro_id",
                table: "Libro",
                column: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Libro");

            migrationBuilder.DropTable(
                name: "Autor");
        }
    }
}
