using System.ComponentModel.DataAnnotations;

namespace Sistema_Control_de_Asistencia_Cervantes.Dominio
{
    public partial class Alumno_Inscribe_Curso
    {
        
        [Key]
        public int AlumnoId { get; set; }

        public virtual Alumno? Alumno { get; set; }

        [Key]
        public int CursoId { get; set; }

        public virtual Curso? Curso { get; set; }
    }
}
