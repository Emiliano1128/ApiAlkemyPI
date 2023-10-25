using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiAlkemyPI.Models
{
    public class TrabajosModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CodTrabajo { get; set; }
        public DateTime Fecha { get; set; }
        public int CodProyecto { get; set; }
        [ForeignKey("CodProyecto")]
        public virtual ProyectosModel ProyectosModel { get; set;}
        public int CodServicio { get; set; }
        [ForeignKey("CodServicio")]
        public virtual ServiciosModel ServiciosModel { get; set; }
        public int CantHoras { get; set; }
        public float ValorHora { get; set; }
        public float Costo { get; set; }
    }
}
