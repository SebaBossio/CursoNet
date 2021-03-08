using Common.DTO;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Common.Exceptions;

namespace Repositories
{
    public class LibrosRepository
    {
        private ExamenFinalContext _context { get; set; }

        public LibrosRepository(ExamenFinalContext context)
        {
            _context = context;
        }

        public void AgregarLibro(Guid id, LibroDTO libroDTO)
        {
            _context.Libros.Add(new DataAccess.Models.Libro()
            {
                Id = id,
                Nombre = libroDTO.Nombre,
                Precio = libroDTO.Precio,
                Activo = true
            }); ;
        }


        public void RemoverLibro(LibroDTO libroDTO)
        {
            var libro = _context.Libros.Where(x => x.Nombre == libroDTO.Nombre).FirstOrDefault();

            if(libro != null)
            {
                libro.Activo = false;
                _context.Libros.Update(libro);
            }
            else
            {
                throw new ExamenFinalException($"No se encontró un libro con el nombre '{libroDTO.Nombre}'.");
            }
        }

        public void ModificarPrecioLibro(LibroDTO libroDTO)
        {
            var libro = _context.Libros.Where(x => x.Nombre == libroDTO.Nombre).FirstOrDefault();

            if (libro != null)
            {
                libro.Precio = libroDTO.Precio;
                _context.Libros.Update(libro);
            }
            else
            {
                throw new ExamenFinalException($"No se encontró un libro con el nombre '{libroDTO.Nombre}'.");
            }
        }
    }
}
