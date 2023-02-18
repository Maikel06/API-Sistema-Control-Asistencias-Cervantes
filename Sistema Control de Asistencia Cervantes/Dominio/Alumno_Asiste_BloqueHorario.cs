using Sistema_Control_de_Asistencia_Cervantes.Dominio;
using System.ComponentModel.DataAnnotations;

namespace Sistema_Control_de_Asistencia_Cervantes.Dominio
{
    public partial class Alumno_Asiste_BloqueHorario
    {
        [Key]
        public int BloqueHorarioId { get; set; }

        public virtual BloqueHorario? BloqueHorario { get; set; }

        [Key]
        public int AlumnoId { get; set; }

        public virtual Alumno? Alumno { get; set; }

        public DateOnly Fecha { get; set; }
        public char Estado { get; set; } // P Presente, J AusenciaJustificada, I AusenciaInjustificada





    }
}
