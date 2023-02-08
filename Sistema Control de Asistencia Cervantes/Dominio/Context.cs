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
        public DbSet<Encargado> Encargado { get; set; };

        public DbSet<Curso> Curso { get; set; }

        public DbSet<BloqueHorario> BloqueHorario { get; set; }

        public DbSet<Usuario_Imparte_Curso> Usuario_Imparte_Curso { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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

            modelBuilder.Entity<BloqueHorario>()
                .HasOne(b => b.Curso)
                .WithMany(c => c.BloquesHorario)
                .HasForeignKey(b => b.CursoId);
        }

    }
}
