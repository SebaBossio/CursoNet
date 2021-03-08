using Common.DTO;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Common.Exceptions;

namespace Repositories
{
    public class HistorialMovimientosStockRepository
    {
        private ExamenFinalContext _context { get; set; }

        public HistorialMovimientosStockRepository(ExamenFinalContext context)
        {
            _context = context;
        }

        public void AgregarMovimientoStock(MovimientoStockDTO movimientoStockDTO)
        {
            var libro = _context.Libros.Where(x => x.Nombre == movimientoStockDTO.NombreLibro).FirstOrDefault();
            var stock = _context.Stocks.Where(x => x.LibroId == libro.Id).FirstOrDefault();

            if (stock != null)
            {
                _context.HistorialMovimientosStocks.Add(new DataAccess.Models.HistorialMovimientosStock(){
                    FechaModificacion = DateTime.Now,
                    StockId = stock.Id,
                    StockAnterior = movimientoStockDTO.CantidadAnterior,
                    StockNuevo = movimientoStockDTO.CantidadNueva
                });
            }
            else
            {
                throw new ExamenFinalException($"No se encontró un libro con el nombre '{movimientoStockDTO.NombreLibro}'.");
            }
        }
    }
}
