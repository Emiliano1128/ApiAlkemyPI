using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAlkemyPI.Models
{
    public class ProyectosModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CodProyecto { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public int Estado { get; set; } // 1=pendiente 2=condirmado 3=terminado

    }
}
