using DataAccess.Infraestructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccess.Models
{
    public class HistorialMovimientosStock : EntityBase
    {
        [Column(TypeName = "UNIQUEIDENTIFIER")]
        public Guid StockId { get; set; }
        [Column(TypeName = "DATETIME")]
        public DateTime FechaModificacion { get; set; }
        [Column(TypeName = "INT")]
        public int StockAnterior { get; set; }
        [Column(TypeName = "INT")]
        public int StockNuevo { get; set; }

        [ForeignKey("StockId")]
        public virtual Stock Stock { get; set; }
    }
}
