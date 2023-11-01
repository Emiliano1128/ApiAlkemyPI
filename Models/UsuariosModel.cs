using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiAlkemyPI.Models
{
    public class UsuariosModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CodUsuario { get; set; }
        public string Nombre { get; set; }
        public int Dni { get; set; }
        public bool Tipo { get; set; }
        public string Contraseña { get; set; }
        //Falta el tipo de dato para la Contraseña
    }
}
