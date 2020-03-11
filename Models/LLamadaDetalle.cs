using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SegundoParcialApli2.Models
{
    public class LlamadaDetalle
    {
        [Key]
        public int LlamadaDetalleId { get; set; }
        public int LlamadaId { get; set; }
        public string Problema { get; set; }
        public string Solucion { get; set; }

        public LlamadaDetalle()
        {
            LlamadaDetalleId = 0;
            LlamadaId = 0;
            Problema = string.Empty;
            Solucion = string.Empty;
        }
    }
}
