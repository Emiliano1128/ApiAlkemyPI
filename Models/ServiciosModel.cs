using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiAlkemyPI.Models
{
    public class ServiciosModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CodServicio { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
        public float ValorHora { get; set; }


    }
}
