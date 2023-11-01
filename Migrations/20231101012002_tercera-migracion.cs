using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiAlkemyPI.Migrations
{
    /// <inheritdoc />
    public partial class terceramigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Contraseña",
                table: "UsuariosModels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Contraseña",
                table: "UsuariosModels");
        }
    }
}
