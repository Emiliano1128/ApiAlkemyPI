using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiAlkemyPI.Models
{
    public class UsuariosModel
    {
        
        public string Nombre { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CodUsuario { get; set; }
        public int Dni { get; set; }
        public bool Tipo { get; set; }
        public string Contraseña { get; set; }
    }
}
