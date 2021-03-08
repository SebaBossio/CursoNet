using DataAccess.Infraestructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccess.Models
{
    public class Stock : EntityBase
    {
        [Column(TypeName = "UNIQUEIDENTIFIER")]
        public Guid LibroId { get; set; }
        [Column(TypeName = "INT")]
        public int Cantidad { get; set; }

        [ForeignKey("LibroId")]
        public virtual Libro Libro { get; set; }
    }
}
