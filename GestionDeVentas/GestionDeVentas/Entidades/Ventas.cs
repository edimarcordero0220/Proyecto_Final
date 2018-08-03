using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionDeVentas.Entidades
{
    public class Ventas
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int VentaId { get; set; }
        public int VendedorId { get; set; }
        public DateTime Fecha { get; set; }
        public float Total { get; set; }
        public float Comision { get; set; }
    }
}