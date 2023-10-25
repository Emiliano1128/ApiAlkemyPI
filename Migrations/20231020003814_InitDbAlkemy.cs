using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiAlkemyPI.Migrations
{
    /// <inheritdoc />
    public partial class InitDbAlkemy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProyectosModels",
                columns: table => new
                {
                    CodProyecto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProyectosModels", x => x.CodProyecto);
                });

            migrationBuilder.CreateTable(
                name: "ServiciosModels",
                columns: table => new
                {
                    CodServicio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    ValorHora = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiciosModels", x => x.CodServicio);
                });

            migrationBuilder.CreateTable(
                name: "UsuariosModels",
                columns: table => new
                {
                    CodUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dni = table.Column<int>(type: "int", nullable: false),
                    Tipo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuariosModels", x => x.CodUsuario);
                });

            migrationBuilder.CreateTable(
                name: "TrabajosModels",
                columns: table => new
                {
                    CodTrabajo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CodProyecto = table.Column<int>(type: "int", nullable: false),
                    CodServicio = table.Column<int>(type: "int", nullable: false),
                    CantHoras = table.Column<int>(type: "int", nullable: false),
                    ValorHora = table.Column<float>(type: "real", nullable: false),
                    Costo = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrabajosModels", x => x.CodTrabajo);
                    table.ForeignKey(
                        name: "FK_TrabajosModels_ProyectosModels_CodProyecto",
                        column: x => x.CodProyecto,
                        principalTable: "ProyectosModels",
                        principalColumn: "CodProyecto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrabajosModels_ServiciosModels_CodServicio",
                        column: x => x.CodServicio,
                        principalTable: "ServiciosModels",
                        principalColumn: "CodServicio",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrabajosModels_CodProyecto",
                table: "TrabajosModels",
                column: "CodProyecto");

            migrationBuilder.CreateIndex(
                name: "IX_TrabajosModels_CodServicio",
                table: "TrabajosModels",
                column: "CodServicio");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrabajosModels");

            migrationBuilder.DropTable(
                name: "UsuariosModels");

            migrationBuilder.DropTable(
                name: "ProyectosModels");

            migrationBuilder.DropTable(
                name: "ServiciosModels");
        }
    }
}
