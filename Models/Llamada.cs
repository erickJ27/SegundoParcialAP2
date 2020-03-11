using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SegundoParcialApli2.Models
{
    public class Llamada
    {
        [Key]
        public int LlamadaId { get; set; }
        [Required(ErrorMessage ="La descripcion no puede estar vacia")]
        public string Descripcion { get; set; }

        [ForeignKey("LlamadaId")]
        public List<LlamadaDetalle> Detalle { get; set; }

        public Llamada()
        {
            LlamadaId = 0;
            Descripcion = string.Empty;
            Detalle = new List<LlamadaDetalle>();
        }
    }
}
