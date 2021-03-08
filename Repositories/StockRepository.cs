using Common.DTO;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Common.Exceptions;

namespace Repositories
{
    public class StockRepository
    {
        private ExamenFinalContext _context { get; set; }

        public StockRepository(ExamenFinalContext context)
        {
            _context = context;
        }

        public void AgregarStock(StockDTO stockDTO)
        {
            int a = int.Parse("aa");
            _context.Stocks.Add(new DataAccess.Models.Stock()
            {
                LibroId = stockDTO.LibroId,
                Cantidad = stockDTO.Cantidad
            });
        }

        public void ModificarStock(StockDTO stockDTO)
        {
            var libro = _context.Libros.Where(x => x.Nombre == stockDTO.NombreLibro).FirstOrDefault();
            var stock = _context.Stocks.Where(x => x.LibroId == libro.Id).FirstOrDefault();

            if (stock != null)
            {
                stock.Cantidad = stockDTO.Cantidad;
                _context.Stocks.Update(stock);
            }
            else
            {
                throw new ExamenFinalException($"No se encontró un libro con el nombre '{stockDTO.NombreLibro}'.");
            }
        }

        public int GetCantidad(StockDTO stockDTO)
        {
            int result = -1;

            var libro = _context.Libros.Where(x => x.Nombre == stockDTO.NombreLibro).FirstOrDefault();
            var stock = _context.Stocks.Where(x => x.LibroId == libro.Id).FirstOrDefault();

            if (stock != null)
            {
                result = stock.Cantidad;
            }
            else
            {
                throw new ExamenFinalException($"No se encontró un libro con el nombre '{stockDTO.NombreLibro}'.");
            }

            return result;
        }
    }
}
