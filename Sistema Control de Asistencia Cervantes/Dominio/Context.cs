using API_Lab.Models;
using Microsoft.EntityFrameworkCore;

namespace Sistema_Control_de_Asistencia_Cervantes.Dominio
{
    public partial class Context : DbContext
    {

        public Context() { }
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuario { get; set; }

        public DbSet<Alumno> Alumno { get; set; }

        public DbSet<Encargado> Encargado { get; set; }

        public DbSet<Curso> Curso { get; set; }

        public DbSet<BloqueHorario> BloqueHorario { get; set; }

        public DbSet<Usuario_Imparte_Curso> Usuario_Imparte_Curso { get; set; }

        public DbSet<Alumno_Asiste_BloqueHorario> alumno_Asiste_BloquesHorario { get; set; }

        public DbSet<Usuario_Imparte_BloqueHorario> Usuario_Imparte_BloquesHorario { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //USUARIO IMPARTE CURSO
            modelBuilder.Entity<Usuario_Imparte_Curso>()
                .HasKey(uc => new { uc.UsuarioId, uc.CursoId });

            modelBuilder.Entity<Usuario_Imparte_Curso>()
                .HasOne(uc => uc.Usuario)
                .WithMany(u => u.Usuario_Imparte_Cursos)
                .HasForeignKey(uc => uc.UsuarioId);

            modelBuilder.Entity<Usuario_Imparte_Curso>()
                .HasOne(uc => uc.Curso)
                .WithMany(c => c.Usuario_Imparte_Cursos)
                .HasForeignKey(uc => uc.CursoId);


            //BLOQUE HORARIO
            modelBuilder.Entity<BloqueHorario>()
                .HasOne(b => b.Curso)
                .WithMany(c => c.BloquesHorario)
                .HasForeignKey(b => b.CursoId);


            //ALUMNO ASISTE BLOQUEHORARIO
            modelBuilder.Entity<Alumno_Asiste_BloqueHorario>()
                .HasKey(ab => new { ab.AlumnoId, ab.BloqueHorarioId });

            modelBuilder.Entity<Alumno_Asiste_BloqueHorario>()
                .HasOne(ab => ab.Alumno)
                .WithMany(a => a.Alumno_Asiste_BloqueHorarios)
                .HasForeignKey(ab => ab.AlumnoId);

            modelBuilder.Entity<Alumno_Asiste_BloqueHorario>()
                .HasOne(ab => ab.BloqueHorario)
                .WithMany(b => b.Alumno_Asiste_BloqueHorarios)
                .HasForeignKey(ab => ab.BloqueHorarioId);


            //USUARIO ASISTE BLOQUE HORARIO
            modelBuilder.Entity<Usuario_Imparte_BloqueHorario>()
                .HasKey(ub => new { ub.UsuarioId, ub.BloqueHorarioId });

            modelBuilder.Entity<Usuario_Imparte_BloqueHorario>()
                .HasOne(ub => ub.Usuario)
                .WithMany(u => u.Usuario_Imparte_BloquesHorario)
                .HasForeignKey(ub => ub.UsuarioId);

            modelBuilder.Entity<Usuario_Imparte_BloqueHorario>()
                .HasOne(ub => ub.BloqueHorario)
                .WithMany(b => b.Usuario_Imparte_BloquesHorario)
                .HasForeignKey(ub => ub.BloqueHorarioId);
        }

    }
}
