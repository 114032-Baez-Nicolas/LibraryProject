using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CodeFirstLibraryDb.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autores",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autores", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Generos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Libros",
                columns: table => new
                {
                    ISBN = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaPublicacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    lAutorId = table.Column<int>(type: "int", nullable: false),
                    lGeneroId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libros", x => x.ISBN);
                    table.ForeignKey(
                        name: "FK_Libros_Autores_lAutorId",
                        column: x => x.lAutorId,
                        principalTable: "Autores",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Libros_Generos_lGeneroId",
                        column: x => x.lGeneroId,
                        principalTable: "Generos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Autores",
                columns: new[] { "id", "FechaNacimiento", "Nombre" },
                values: new object[,]
                {
                    { 1, new DateTime(1927, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gabriel García Márquez" },
                    { 2, new DateTime(1914, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Julio Cortázar" },
                    { 3, new DateTime(1936, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mario Vargas Llosa" }
                });

            migrationBuilder.InsertData(
                table: "Generos",
                columns: new[] { "id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Realismo Mágico" },
                    { 2, "Novela" },
                    { 3, "Cuento" }
                });

            migrationBuilder.InsertData(
                table: "Libros",
                columns: new[] { "ISBN", "FechaPublicacion", "Titulo", "lAutorId", "lGeneroId" },
                values: new object[,]
                {
                    { new Guid("1822d238-4774-4643-83d4-55efb415646a"), new DateTime(1963, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "La ciudad y los perros", 3, 3 },
                    { new Guid("19fc2475-4684-4d16-ae52-e2b4c06e2865"), new DateTime(1963, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rayuela", 2, 2 },
                    { new Guid("dca0330b-d89d-438d-bd2f-f12ba1af29c8"), new DateTime(1967, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cien años de soledad", 1, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Libros_lAutorId",
                table: "Libros",
                column: "lAutorId");

            migrationBuilder.CreateIndex(
                name: "IX_Libros_lGeneroId",
                table: "Libros",
                column: "lGeneroId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Libros");

            migrationBuilder.DropTable(
                name: "Autores");

            migrationBuilder.DropTable(
                name: "Generos");
        }
    }
}
