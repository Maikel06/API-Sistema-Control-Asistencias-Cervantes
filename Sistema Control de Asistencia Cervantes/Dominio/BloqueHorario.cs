namespace Sistema_Control_de_Asistencia_Cervantes.Dominio
{
    public partial class BloqueHorario
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public string Dia { get; set; } = null!;
        public TimeOnly hora { get; set; }
        public string nombreMateria { get; set; } = null!;

    }
}
