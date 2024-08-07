﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Sistema_Control_de_Asistencia_Cervantes.Dominio;

#nullable disable

namespace SistemaControldeAsistenciaCervantes.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Sistema_Control_de_Asistencia_Cervantes.Dominio.Alumno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Cedula")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("SeccionId") // Agregar la propiedad para la clave foránea
                    .HasColumnType("integer");

                    b.HasOne("Sistema_Control_de_Asistencia_Cervantes.Dominio.Seccion", "Seccion")
                    .WithMany("Alumnos")
                    .HasForeignKey("SeccionId")
                    .IsRequired();

                    b.Navigation("Seccion");

                    b.HasKey("Id");

                    b.ToTable("Alumno");
                });

            modelBuilder.Entity("Sistema_Control_de_Asistencia_Cervantes.Dominio.Alumno_Asiste_BloqueHorario", b =>
                {
                    b.Property<int>("AlumnoId")
                        .HasColumnType("integer");

                    b.Property<int>("BloqueHorarioId")
                        .HasColumnType("integer");

                    b.Property<char>("Estado")
                        .HasColumnType("character(1)");

                    b.Property<DateOnly>("Fecha")
                        .HasColumnType("date");

                    b.HasKey("AlumnoId", "BloqueHorarioId");

                    b.HasIndex("BloqueHorarioId");

                    b.ToTable("Alumno_Asiste_BloquesHorario");
                });

            modelBuilder.Entity("Sistema_Control_de_Asistencia_Cervantes.Dominio.Alumno_Inscribe_Curso", b =>
                {
                    b.Property<int>("AlumnoId")
                        .HasColumnType("integer");

                    b.Property<int>("CursoId")
                        .HasColumnType("integer");

                    b.HasKey("AlumnoId", "CursoId");

                    b.HasIndex("CursoId");

                    b.ToTable("Alumno_Inscribe_Curso");
                });

            modelBuilder.Entity("Sistema_Control_de_Asistencia_Cervantes.Dominio.BloqueHorario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CursoId")
                        .HasColumnType("integer");

                    b.Property<string>("Dia")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<TimeOnly>("Hora")
                        .HasColumnType("time without time zone");

                    b.Property<int>("Numero")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CursoId");

                    b.ToTable("BloqueHorario");
                });

            modelBuilder.Entity("Sistema_Control_de_Asistencia_Cervantes.Dominio.Curso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Anho")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Seccion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("aula")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Curso");
                });

            modelBuilder.Entity("Sistema_Control_de_Asistencia_Cervantes.Dominio.Encargado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Cedula")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Celular")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Encargado");
                });

            modelBuilder.Entity("Sistema_Control_de_Asistencia_Cervantes.Dominio.Encargado_Cargo_Alumno", b =>
                {
                    b.Property<int>("EncargadoId")
                        .HasColumnType("integer");

                    b.Property<int>("AlumnoId")
                        .HasColumnType("integer");

                    b.HasKey("EncargadoId", "AlumnoId");

                    b.HasIndex("AlumnoId");

                    b.ToTable("Encargado_Cargo_Alumno");
                });

            modelBuilder.Entity("Sistema_Control_de_Asistencia_Cervantes.Dominio.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Contrasenha")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NombreUsuario")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Rol")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("Sistema_Control_de_Asistencia_Cervantes.Dominio.Usuario_Imparte_BloqueHorario", b =>
                {
                    b.Property<int>("UsuarioId")
                        .HasColumnType("integer");

                    b.Property<int>("BloqueHorarioId")
                        .HasColumnType("integer");

                    b.Property<char>("Estado")
                        .HasColumnType("character(1)");

                    b.Property<DateOnly>("Fecha")
                        .HasColumnType("date");

                    b.HasKey("UsuarioId", "BloqueHorarioId");

                    b.HasIndex("BloqueHorarioId");

                    b.ToTable("Usuario_Imparte_BloquesHorario");
                });

            modelBuilder.Entity("Sistema_Control_de_Asistencia_Cervantes.Dominio.Usuario_Imparte_Curso", b =>
                {
                    b.Property<int>("UsuarioId")
                        .HasColumnType("integer");

                    b.Property<int>("CursoId")
                        .HasColumnType("integer");

                    b.Property<bool>("activo")
                        .HasColumnType("boolean");

                    b.HasKey("UsuarioId", "CursoId");

                    b.HasIndex("CursoId");

                    b.ToTable("Usuario_Imparte_Curso");
                });

            modelBuilder.Entity("Sistema_Control_de_Asistencia_Cervantes.Dominio.Alumno_Asiste_BloqueHorario", b =>
                {
                    b.HasOne("Sistema_Control_de_Asistencia_Cervantes.Dominio.Alumno", "Alumno")
                        .WithMany("Alumno_Asiste_BloqueHorarios")
                        .HasForeignKey("AlumnoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sistema_Control_de_Asistencia_Cervantes.Dominio.BloqueHorario", "BloqueHorario")
                        .WithMany("Alumno_Asiste_BloqueHorarios")
                        .HasForeignKey("BloqueHorarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Alumno");

                    b.Navigation("BloqueHorario");
                });

            modelBuilder.Entity("Sistema_Control_de_Asistencia_Cervantes.Dominio.Alumno_Inscribe_Curso", b =>
                {
                    b.HasOne("Sistema_Control_de_Asistencia_Cervantes.Dominio.Alumno", "Alumno")
                        .WithMany("Alumno_Inscribe_Cursos")
                        .HasForeignKey("AlumnoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sistema_Control_de_Asistencia_Cervantes.Dominio.Curso", "Curso")
                        .WithMany("Alumno_Inscribe_Cursos")
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Alumno");

                    b.Navigation("Curso");
                });

            modelBuilder.Entity("Sistema_Control_de_Asistencia_Cervantes.Dominio.BloqueHorario", b =>
                {
                    b.HasOne("Sistema_Control_de_Asistencia_Cervantes.Dominio.Curso", "Curso")
                        .WithMany("BloquesHorario")
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Curso");
                });

            modelBuilder.Entity("Sistema_Control_de_Asistencia_Cervantes.Dominio.Encargado_Cargo_Alumno", b =>
                {
                    b.HasOne("Sistema_Control_de_Asistencia_Cervantes.Dominio.Alumno", "Alumno")
                        .WithMany("Encargado_Cargo_Alumnos")
                        .HasForeignKey("AlumnoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sistema_Control_de_Asistencia_Cervantes.Dominio.Encargado", "Encargado")
                        .WithMany("Encargado_Cargo_Alumnos")
                        .HasForeignKey("EncargadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Alumno");

                    b.Navigation("Encargado");
                });

            modelBuilder.Entity("Sistema_Control_de_Asistencia_Cervantes.Dominio.Usuario_Imparte_BloqueHorario", b =>
                {
                    b.HasOne("Sistema_Control_de_Asistencia_Cervantes.Dominio.BloqueHorario", "BloqueHorario")
                        .WithMany("Usuario_Imparte_BloquesHorario")
                        .HasForeignKey("BloqueHorarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sistema_Control_de_Asistencia_Cervantes.Dominio.Usuario", "Usuario")
                        .WithMany("Usuario_Imparte_BloquesHorario")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BloqueHorario");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Sistema_Control_de_Asistencia_Cervantes.Dominio.Usuario_Imparte_Curso", b =>
                {
                    b.HasOne("Sistema_Control_de_Asistencia_Cervantes.Dominio.Curso", "Curso")
                        .WithMany("Usuario_Imparte_Cursos")
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sistema_Control_de_Asistencia_Cervantes.Dominio.Usuario", "Usuario")
                        .WithMany("Usuario_Imparte_Cursos")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Curso");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Sistema_Control_de_Asistencia_Cervantes.Dominio.GradoAcademico", entity =>
            {
                entity.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("integer");

                entity.Property<string>("Nombre")
                    .IsRequired()
                    .HasColumnType("text");

                entity.HasKey("Id");

                entity.ToTable("Grado");

                entity.HasMany("Sistema_Control_de_Asistencia_Cervantes.Dominio.Seccion", "Secciones")
                .WithOne("GradoAcademico")
                .HasForeignKey("GradoAcademicoId")
                 .IsRequired();

                entity.Navigation("Secciones");

            });

            modelBuilder.Entity("Sistema_Control_de_Asistencia_Cervantes.Dominio.Seccion", entity =>
            {
                entity.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("integer");

                entity.Property<string>("Nombre")
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property<int>("GradoAcademicoId")
                    .HasColumnType("integer");

                entity.HasKey("Id");

                entity.ToTable("Seccion");

                entity.HasOne("Sistema_Control_de_Asistencia_Cervantes.Dominio.GradoAcademico", "GradoAcademico")
                .WithMany("Secciones")
                .HasForeignKey("GradoAcademicoId")
                .IsRequired();

                entity.HasMany("Sistema_Control_de_Asistencia_Cervantes.Dominio.Alumno", "Alumnos")
                .WithOne("Seccion")
                .HasForeignKey("SeccionId")
                 .IsRequired();

                entity.Navigation("Alumnos");

                entity.Navigation("GradoAcademico");

            });

            modelBuilder.Entity("Sistema_Control_de_Asistencia_Cervantes.Dominio.Alumno", b =>
                {
                    b.Navigation("Alumno_Asiste_BloqueHorarios");

                    b.Navigation("Alumno_Inscribe_Cursos");

                    b.Navigation("Encargado_Cargo_Alumnos");
                });

            modelBuilder.Entity("Sistema_Control_de_Asistencia_Cervantes.Dominio.BloqueHorario", b =>
                {
                    b.Navigation("Alumno_Asiste_BloqueHorarios");

                    b.Navigation("Usuario_Imparte_BloquesHorario");
                });

            modelBuilder.Entity("Sistema_Control_de_Asistencia_Cervantes.Dominio.Curso", b =>
                {
                    b.Navigation("Alumno_Inscribe_Cursos");

                    b.Navigation("BloquesHorario");

                    b.Navigation("Usuario_Imparte_Cursos");
                });

            modelBuilder.Entity("Sistema_Control_de_Asistencia_Cervantes.Dominio.Encargado", b =>
                {
                    b.Navigation("Encargado_Cargo_Alumnos");
                });

            modelBuilder.Entity("Sistema_Control_de_Asistencia_Cervantes.Dominio.Usuario", b =>
                {
                    b.Navigation("Usuario_Imparte_BloquesHorario");

                    b.Navigation("Usuario_Imparte_Cursos");
                });
#pragma warning restore 612, 618
        }
    }
}
