namespace Sistema_Control_de_Asistencia_Cervantes.Dominio
{
    public partial class Alumno
    {
        
        public Alumno() { 
        }

        public int Id { get; set; }
        public String Cedula { get; set; } = null!;
        public String Nombre { get; set; } = null!;
        public String Apellidos { get; set; } = null!;

        public int SeccionId { get; set; }

        public virtual Seccion? Seccion { get; set; } = null!;



    }
}
