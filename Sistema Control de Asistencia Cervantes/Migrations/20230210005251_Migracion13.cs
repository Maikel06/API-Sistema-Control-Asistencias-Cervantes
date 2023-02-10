using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaControldeAsistenciaCervantes.Migrations
{
    /// <inheritdoc />
    public partial class Migracion13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alumno_Asiste_BloqueHorario_Alumno_AlumnoId",
                table: "Alumno_Asiste_BloqueHorario");

            migrationBuilder.DropForeignKey(
                name: "FK_Alumno_Asiste_BloqueHorario_BloqueHorario_BloqueHorarioId",
                table: "Alumno_Asiste_BloqueHorario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Alumno_Asiste_BloqueHorario",
                table: "Alumno_Asiste_BloqueHorario");

            migrationBuilder.RenameTable(
                name: "Alumno_Asiste_BloqueHorario",
                newName: "alumno_Asiste_BloquesHorario");

            migrationBuilder.RenameColumn(
                name: "Contraseña",
                table: "Usuario",
                newName: "Contrasenha");

            migrationBuilder.RenameColumn(
                name: "Sigla",
                table: "Curso",
                newName: "aula");

            migrationBuilder.RenameIndex(
                name: "IX_Alumno_Asiste_BloqueHorario_BloqueHorarioId",
                table: "alumno_Asiste_BloquesHorario",
                newName: "IX_alumno_Asiste_BloquesHorario_BloqueHorarioId");

            migrationBuilder.AddColumn<bool>(
                name: "activo",
                table: "Usuario_Imparte_Curso",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_alumno_Asiste_BloquesHorario",
                table: "alumno_Asiste_BloquesHorario",
                columns: new[] { "AlumnoId", "BloqueHorarioId" });

            migrationBuilder.CreateTable(
                name: "Usuario_Imparte_BloquesHorario",
                columns: table => new
                {
                    BloqueHorarioId = table.Column<int>(type: "integer", nullable: false),
                    UsuarioId = table.Column<int>(type: "integer", nullable: false),
                    Fecha = table.Column<DateOnly>(type: "date", nullable: false),
                    Estado = table.Column<char>(type: "character(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario_Imparte_BloquesHorario", x => new { x.UsuarioId, x.BloqueHorarioId });
                    table.ForeignKey(
                        name: "FK_Usuario_Imparte_BloquesHorario_BloqueHorario_BloqueHorarioId",
                        column: x => x.BloqueHorarioId,
                        principalTable: "BloqueHorario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Usuario_Imparte_BloquesHorario_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Imparte_BloquesHorario_BloqueHorarioId",
                table: "Usuario_Imparte_BloquesHorario",
                column: "BloqueHorarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_alumno_Asiste_BloquesHorario_Alumno_AlumnoId",
                table: "alumno_Asiste_BloquesHorario",
                column: "AlumnoId",
                principalTable: "Alumno",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_alumno_Asiste_BloquesHorario_BloqueHorario_BloqueHorarioId",
                table: "alumno_Asiste_BloquesHorario",
                column: "BloqueHorarioId",
                principalTable: "BloqueHorario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_alumno_Asiste_BloquesHorario_Alumno_AlumnoId",
                table: "alumno_Asiste_BloquesHorario");

            migrationBuilder.DropForeignKey(
                name: "FK_alumno_Asiste_BloquesHorario_BloqueHorario_BloqueHorarioId",
                table: "alumno_Asiste_BloquesHorario");

            migrationBuilder.DropTable(
                name: "Usuario_Imparte_BloquesHorario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_alumno_Asiste_BloquesHorario",
                table: "alumno_Asiste_BloquesHorario");

            migrationBuilder.DropColumn(
                name: "activo",
                table: "Usuario_Imparte_Curso");

            migrationBuilder.RenameTable(
                name: "alumno_Asiste_BloquesHorario",
                newName: "Alumno_Asiste_BloqueHorario");

            migrationBuilder.RenameColumn(
                name: "Contrasenha",
                table: "Usuario",
                newName: "Contraseña");

            migrationBuilder.RenameColumn(
                name: "aula",
                table: "Curso",
                newName: "Sigla");

            migrationBuilder.RenameIndex(
                name: "IX_alumno_Asiste_BloquesHorario_BloqueHorarioId",
                table: "Alumno_Asiste_BloqueHorario",
                newName: "IX_Alumno_Asiste_BloqueHorario_BloqueHorarioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Alumno_Asiste_BloqueHorario",
                table: "Alumno_Asiste_BloqueHorario",
                columns: new[] { "AlumnoId", "BloqueHorarioId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Alumno_Asiste_BloqueHorario_Alumno_AlumnoId",
                table: "Alumno_Asiste_BloqueHorario",
                column: "AlumnoId",
                principalTable: "Alumno",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Alumno_Asiste_BloqueHorario_BloqueHorario_BloqueHorarioId",
                table: "Alumno_Asiste_BloqueHorario",
                column: "BloqueHorarioId",
                principalTable: "BloqueHorario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
