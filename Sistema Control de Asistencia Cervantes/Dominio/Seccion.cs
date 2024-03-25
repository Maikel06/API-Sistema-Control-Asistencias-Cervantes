namespace Sistema_Control_de_Asistencia_Cervantes.Dominio
{
    public class Seccion
    {
        public int Id { get; set; }
        public string Nombre {  get; set; } = null!;

        public int GradoAcademicoId { get; set; }

        public virtual GradoAcademico? GradoAcademico { get; set; } = null!;
    }
}
