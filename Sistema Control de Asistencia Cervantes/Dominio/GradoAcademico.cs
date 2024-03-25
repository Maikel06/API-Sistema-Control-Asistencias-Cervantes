namespace Sistema_Control_de_Asistencia_Cervantes.Dominio
{
    public class GradoAcademico
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Seccion> Secciones { get; set; } = new HashSet<Seccion>();
    }
}
