using System;
using System.Collections.Generic;
using System.Text;

namespace Common.DTO
{
    public class StockDTO
    {
        public string NombreLibro { get; set; }
        public Guid LibroId { get; set; }
        public int Cantidad { get; set; }
    }
}
