using System.ComponentModel.DataAnnotations;

namespace Sistema_Control_de_Asistencia_Cervantes.Dominio
{
    public class Encargado_Cargo_Alumno
    {

        [Key]
        public int EncargadoId { get; set; }

        public virtual Encargado? Encargado { get; set; }

        [Key]
        public int AlumnoId { get; set; }

        public virtual Alumno? Alumno { get; set; }


    }
}
