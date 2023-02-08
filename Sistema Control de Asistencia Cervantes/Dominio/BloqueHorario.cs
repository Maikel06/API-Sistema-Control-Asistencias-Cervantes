namespace Sistema_Control_de_Asistencia_Cervantes.Dominio
{
    public partial class BloqueHorario
    {

        public BloqueHorario() {
            Alumno_Asiste_BloqueHorarios = new HashSet<Alumno_Asiste_BloqueHorario>();
        }
      
        public int Id { get; set; }
        public int Numero { get; set; }
        public string Dia { get; set; } = null!;
        public TimeOnly Hora { get; set; }

        public int CursoId { get; set; }
        public virtual Curso? Curso { get; set; } = null!;

        
        public virtual ICollection<Alumno_Asiste_BloqueHorario> Alumno_Asiste_BloqueHorarios { get; set; }

    }
}
