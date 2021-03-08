using Common.DTO;
using Common.Exceptions;
using DataAccess;
using Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class LibreriaService
    {
        private readonly ExamenFinalContext _context;
        private readonly LibrosRepository librosRepository;
        private readonly StockRepository stockRepository;
        private readonly HistorialMovimientosStockRepository historialMovimientosStockRepository;
        private readonly LogErroresRepository logErroresRepository;

        public LibreriaService()
        {
            _context = new ExamenFinalContext();

            librosRepository = new LibrosRepository(_context);
            stockRepository = new StockRepository(_context);
            historialMovimientosStockRepository = new HistorialMovimientosStockRepository(_context);
            logErroresRepository = new LogErroresRepository(_context);
        }

        public ResponseDTO AgregarLibro(LibroDTO libroDTO)
        {
            ResponseDTO result = new ResponseDTO();
            try
            {
                var newGuid = Guid.NewGuid();
                librosRepository.AgregarLibro(newGuid, libroDTO);
                stockRepository.AgregarStock(new StockDTO()
                {
                    LibroId = newGuid,
                    Cantidad = 0
                });
                _context.SaveChanges();
            }
            catch (ExamenFinalException ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error inesperado.";
                logErroresRepository.AgregarLogError(ex.ToString());
            }

            return result;
        }

        public ResponseDTO RemoverLibro(LibroDTO libroDTO)
        {
            ResponseDTO result = new ResponseDTO();
            try
            {
                librosRepository.RemoverLibro(libroDTO);
                _context.SaveChanges();
            }
            catch (ExamenFinalException ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error inesperado.";
                logErroresRepository.AgregarLogError(ex.ToString());
            }

            return result;
        }

        public ResponseDTO ModificarStock(StockDTO stockDTO)
        {
            ResponseDTO result = new ResponseDTO();
            try
            {
                var cantidadAnterior = stockRepository.GetCantidad(stockDTO);
                stockRepository.ModificarStock(stockDTO);
                historialMovimientosStockRepository.AgregarMovimientoStock(new MovimientoStockDTO()
                {
                    NombreLibro = stockDTO.NombreLibro,
                    CantidadAnterior = cantidadAnterior,
                    CantidadNueva = stockDTO.Cantidad
                });
                _context.SaveChanges();
            }
            catch (ExamenFinalException ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error inesperado.";
                logErroresRepository.AgregarLogError(ex.ToString());
            }

            return result;
        }

        public ResponseDTO ModificarPrecio(LibroDTO libroDTO)
        {
            ResponseDTO result = new ResponseDTO();
            try
            {
                librosRepository.ModificarPrecioLibro(libroDTO);
                _context.SaveChanges();
            }
            catch (ExamenFinalException ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error inesperado.";
                logErroresRepository.AgregarLogError(ex.ToString());
            }

            return result;
        }
    }
}
