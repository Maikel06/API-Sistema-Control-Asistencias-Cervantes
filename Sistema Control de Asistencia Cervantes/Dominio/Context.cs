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

        public DbSet<User> User { get; set; }

       
    }
}
