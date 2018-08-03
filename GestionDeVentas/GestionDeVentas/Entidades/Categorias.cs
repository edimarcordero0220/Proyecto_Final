using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionDeVentas.Entidades
{
    public class Categorias
    {
        [Key]

        public int CategoriaId { get; set; }
        public string Nombre { get; set; }
        public int MaximoVentaDefault { get; set; }
    }
}