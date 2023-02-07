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
       
    }
}
