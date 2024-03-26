using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Sistema_Control_de_Asistencia_Cervantes.Dominio;

#nullable disable

namespace SistemaControldeAsistenciaCervantes.Migrations
{
    /// <inheritdoc />
    public partial class Migracion1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GradoAcademico",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                  .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false)
                },
                 constraints: table =>
                 {
                     table.PrimaryKey("PK_GradoAcademico", x => x.Id);
                 });

            migrationBuilder.CreateTable(
                         name: "Seccion",
                        columns: table => new
                        {
                            Id = table.Column<int>(type: "integer", nullable: false)
                         .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                            Nombre = table.Column<string>(type: "text", nullable: false),
                            GradoAcademicoId = table.Column<int>(type: "integer", nullable: false)
                        },
                     constraints: table =>
                     {
                         table.PrimaryKey("PK_Seccion", x => x.Id);
                         table.ForeignKey(
                             name: "FK_Seccion_GradoAcademico_GradoAcademicoId",
                             column: x => x.GradoAcademicoId,
                             principalTable: "GradoAcademico",
                             principalColumn: "Id",
                             onDelete: ReferentialAction.Cascade);
                     });
            migrationBuilder.CreateTable(
                name: "Alumno",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Cedula = table.Column<string>(type: "text", nullable: false),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Apellidos = table.Column<string>(type: "text", nullable: false),
                    SeccionId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alumno", x => x.Id); 
                    table.ForeignKey(
                    name: "FK_Alumno_Seccion_SeccionId", // Nombre de la clave foránea
                    column: x => x.SeccionId,
                    principalTable: "Seccion", // Nombre de la tabla de destino
                    principalColumn: "Id", // Nombre de la columna de la tabla de destino
                    onDelete: ReferentialAction.Cascade); // Acción en cascada en caso de eliminación de la entidad relacionada
                });


            migrationBuilder.CreateTable(
                name: "Curso",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Seccion = table.Column<string>(type: "text", nullable: false),
                    aula = table.Column<string>(type: "text", nullable: false),
                    Anho = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curso", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Encargado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Apellidos = table.Column<string>(type: "text", nullable: false),
                    Cedula = table.Column<string>(type: "text", nullable: false),
                    Correo = table.Column<string>(type: "text", nullable: false),
                    Celular = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Encargado", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Apellido = table.Column<string>(type: "text", nullable: false),
                    Contrasenha = table.Column<string>(type: "text", nullable: false),
                    Rol = table.Column<bool>(type: "boolean", nullable: false),
                    NombreUsuario = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Alumno_Inscribe_Curso",
                columns: table => new
                {
                    AlumnoId = table.Column<int>(type: "integer", nullable: false),
                    CursoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alumno_Inscribe_Curso", x => new { x.AlumnoId, x.CursoId });
                    table.ForeignKey(
                        name: "FK_Alumno_Inscribe_Curso_Alumno_AlumnoId",
                        column: x => x.AlumnoId,
                        principalTable: "Alumno",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Alumno_Inscribe_Curso_Curso_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Curso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BloqueHorario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Numero = table.Column<int>(type: "integer", nullable: false),
                    Dia = table.Column<string>(type: "text", nullable: false),
                    Hora = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    CursoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloqueHorario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BloqueHorario_Curso_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Curso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Encargado_Cargo_Alumno",
                columns: table => new
                {
                    EncargadoId = table.Column<int>(type: "integer", nullable: false),
                    AlumnoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Encargado_Cargo_Alumno", x => new { x.EncargadoId, x.AlumnoId });
                    table.ForeignKey(
                        name: "FK_Encargado_Cargo_Alumno_Alumno_AlumnoId",
                        column: x => x.AlumnoId,
                        principalTable: "Alumno",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Encargado_Cargo_Alumno_Encargado_EncargadoId",
                        column: x => x.EncargadoId,
                        principalTable: "Encargado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuario_Imparte_Curso",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "integer", nullable: false),
                    CursoId = table.Column<int>(type: "integer", nullable: false),
                    activo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario_Imparte_Curso", x => new { x.UsuarioId, x.CursoId });
                    table.ForeignKey(
                        name: "FK_Usuario_Imparte_Curso_Curso_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Curso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Usuario_Imparte_Curso_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Alumno_Asiste_BloquesHorario",
                columns: table => new
                {
                    BloqueHorarioId = table.Column<int>(type: "integer", nullable: false),
                    AlumnoId = table.Column<int>(type: "integer", nullable: false),
                    Fecha = table.Column<DateOnly>(type: "date", nullable: false),
                    Estado = table.Column<char>(type: "character(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alumno_Asiste_BloquesHorario", x => new { x.AlumnoId, x.BloqueHorarioId });
                    table.ForeignKey(
                        name: "FK_Alumno_Asiste_BloquesHorario_Alumno_AlumnoId",
                        column: x => x.AlumnoId,
                        principalTable: "Alumno",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Alumno_Asiste_BloquesHorario_BloqueHorario_BloqueHorarioId",
                        column: x => x.BloqueHorarioId,
                        principalTable: "BloqueHorario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_Alumno_Asiste_BloquesHorario_BloqueHorarioId",
                table: "Alumno_Asiste_BloquesHorario",
                column: "BloqueHorarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Alumno_Inscribe_Curso_CursoId",
                table: "Alumno_Inscribe_Curso",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_BloqueHorario_CursoId",
                table: "BloqueHorario",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Encargado_Cargo_Alumno_AlumnoId",
                table: "Encargado_Cargo_Alumno",
                column: "AlumnoId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Imparte_BloquesHorario_BloqueHorarioId",
                table: "Usuario_Imparte_BloquesHorario",
                column: "BloqueHorarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Imparte_Curso_CursoId",
                table: "Usuario_Imparte_Curso",
                column: "CursoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alumno_Asiste_BloquesHorario");

            migrationBuilder.DropTable(
                name: "Alumno_Inscribe_Curso");

            migrationBuilder.DropTable(
                name: "Encargado_Cargo_Alumno");

            migrationBuilder.DropTable(
                name: "Usuario_Imparte_BloquesHorario");

            migrationBuilder.DropTable(
                name: "Usuario_Imparte_Curso");

            migrationBuilder.DropTable(
                name: "Alumno");

            migrationBuilder.DropTable(
                name: "Encargado");

            migrationBuilder.DropTable(
                name: "BloqueHorario");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Curso");

            migrationBuilder.DropTable(
                name: "GradoAcademico");

            migrationBuilder.DropTable(
                name: "Seccion");
        }
    }
}
