namespace Sistema_Control_de_Asistencia_Cervantes.Dominio
{
    public partial class Encargado
    {

        public Encargado() {
            Alumnos = new HashSet<Alumno>();
        }

        public int Id { get; set; }
        public String Nombre { get; set; } = null!;
        public String Apellidos { get; set; } = null!;
        public String Cedula { get; set; } = null!;
        public String Correo { get; set; } = null!;
        public String Celular { get; set; } = null!;

        public virtual ICollection<Alumno> Alumnos { get; set; }
    }
}
