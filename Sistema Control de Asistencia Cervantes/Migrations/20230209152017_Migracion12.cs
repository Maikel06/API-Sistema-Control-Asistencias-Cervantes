using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaControldeAsistenciaCervantes.Migrations
{
    /// <inheritdoc />
    public partial class Migracion12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Seccion",
                table: "Alumno");

            migrationBuilder.CreateTable(
                name: "Alumno_Asiste_BloqueHorario",
                columns: table => new
                {
                    BloqueHorarioId = table.Column<int>(type: "integer", nullable: false),
                    AlumnoId = table.Column<int>(type: "integer", nullable: false),
                    Fecha = table.Column<DateOnly>(type: "date", nullable: false),
                    Estado = table.Column<char>(type: "character(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alumno_Asiste_BloqueHorario", x => new { x.AlumnoId, x.BloqueHorarioId });
                    table.ForeignKey(
                        name: "FK_Alumno_Asiste_BloqueHorario_Alumno_AlumnoId",
                        column: x => x.AlumnoId,
                        principalTable: "Alumno",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Alumno_Asiste_BloqueHorario_BloqueHorario_BloqueHorarioId",
                        column: x => x.BloqueHorarioId,
                        principalTable: "BloqueHorario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AlumnoCurso",
                columns: table => new
                {
                    AlumnosId = table.Column<int>(type: "integer", nullable: false),
                    CursosId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlumnoCurso", x => new { x.AlumnosId, x.CursosId });
                    table.ForeignKey(
                        name: "FK_AlumnoCurso_Alumno_AlumnosId",
                        column: x => x.AlumnosId,
                        principalTable: "Alumno",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlumnoCurso_Curso_CursosId",
                        column: x => x.CursosId,
                        principalTable: "Curso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AlumnoEncargado",
                columns: table => new
                {
                    AlumnosId = table.Column<int>(type: "integer", nullable: false),
                    EncargadosId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlumnoEncargado", x => new { x.AlumnosId, x.EncargadosId });
                    table.ForeignKey(
                        name: "FK_AlumnoEncargado_Alumno_AlumnosId",
                        column: x => x.AlumnosId,
                        principalTable: "Alumno",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlumnoEncargado_Encargado_EncargadosId",
                        column: x => x.EncargadosId,
                        principalTable: "Encargado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alumno_Asiste_BloqueHorario_BloqueHorarioId",
                table: "Alumno_Asiste_BloqueHorario",
                column: "BloqueHorarioId");

            migrationBuilder.CreateIndex(
                name: "IX_AlumnoCurso_CursosId",
                table: "AlumnoCurso",
                column: "CursosId");

            migrationBuilder.CreateIndex(
                name: "IX_AlumnoEncargado_EncargadosId",
                table: "AlumnoEncargado",
                column: "EncargadosId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alumno_Asiste_BloqueHorario");

            migrationBuilder.DropTable(
                name: "AlumnoCurso");

            migrationBuilder.DropTable(
                name: "AlumnoEncargado");

            migrationBuilder.AddColumn<string>(
                name: "Seccion",
                table: "Alumno",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
