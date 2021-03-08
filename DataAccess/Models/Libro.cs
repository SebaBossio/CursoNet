using DataAccess.Infraestructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccess.Models
{
    public class Libro : EntityBase
    {
        [Column(TypeName = "VARCHAR(500)")]
        public string Nombre { get; set; }
        [Column(TypeName = "MONEY")]
        public decimal Precio { get; set; }
        [Column(TypeName = "BIT")]
        public bool Activo { get; set; }
    }
}
