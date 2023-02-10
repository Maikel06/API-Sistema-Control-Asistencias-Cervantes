using API_Lab.Models;
using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_Control_de_Asistencia_Cervantes.Dominio
{
    public partial class Usuario_Imparte_Curso
    {
        [Key]
        public int UsuarioId { get; set; }

        public virtual Usuario? Usuario { get; set; }

        [Key]
        public int CursoId { get; set; }

        public virtual Curso? Curso { get; set; }

        public Boolean activo { get; set; }
    }
}
