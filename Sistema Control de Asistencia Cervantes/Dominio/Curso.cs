namespace Sistema_Control_de_Asistencia_Cervantes.Dominio
{
    public partial class Curso
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Seccion { get; set; } = null!;
        public string Sigla { get; set; } = null!;
        public int Anho { get; set; }
    }
}
