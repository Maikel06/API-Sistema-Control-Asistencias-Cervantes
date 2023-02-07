using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaControldeAsistenciaCervantes.Migrations
{
    /// <inheritdoc />
    public partial class Migracion5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "User",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "User",
                newName: "Contraseña");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "User",
                newName: "Apellido");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "User",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "Contraseña",
                table: "User",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Apellido",
                table: "User",
                newName: "LastName");
        }
    }
}
