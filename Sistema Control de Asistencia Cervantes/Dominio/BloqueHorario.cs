namespace Sistema_Control_de_Asistencia_Cervantes.Dominio
{
    public partial class BloqueHorario
    {

        public BloqueHorario() {
            Alumno_Asiste_BloqueHorarios = new HashSet<Alumno_Asiste_BloqueHorario>();
            Usuario_Imparte_BloquesHorario = new HashSet<Usuario_Imparte_BloqueHorario>();
        }
      
        public int Id { get; set; }
        public int Numero { get; set; }
        public char Dia { get; set; }
        public TimeOnly Hora { get; set; }

        public int CursoId { get; set; }
        public virtual Curso? Curso { get; set; } = null!;

        public virtual ICollection<Alumno_Asiste_BloqueHorario> Alumno_Asiste_BloqueHorarios { get; set; }

        public virtual ICollection<Usuario_Imparte_BloqueHorario> Usuario_Imparte_BloquesHorario { get; set; }

    }
}
