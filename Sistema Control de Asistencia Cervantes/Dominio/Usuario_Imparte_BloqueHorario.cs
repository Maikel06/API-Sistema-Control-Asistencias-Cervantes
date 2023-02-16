using Sistema_Control_de_Asistencia_Cervantes.Dominio;
using System.ComponentModel.DataAnnotations;

namespace Sistema_Control_de_Asistencia_Cervantes.Dominio
{
    public partial class Usuario_Imparte_BloqueHorario
    {
        [Key]
        public int BloqueHorarioId { get; set; }

        public virtual BloqueHorario? BloqueHorario { get; set; }

        [Key]
        public int UsuarioId { get; set; }

        public virtual Usuario? Usuario { get; set; }

        public DateOnly Fecha { get; set; }
        public char Estado { get; set; }
    }
}
