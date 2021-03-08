using System;
using System.Collections.Generic;
using System.Text;

namespace Common.DTO
{
    public class MovimientoStockDTO
    {
        public string NombreLibro { get; set; }
        public int CantidadAnterior { get; set; }
        public int CantidadNueva { get; set; }
    }
}
