using DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories
{
    public class LogErroresRepository
    {
        private ExamenFinalContext _context { get; set; }

        public LogErroresRepository(ExamenFinalContext context)
        {
            _context = context;
        }

        public void AgregarLogError(string error)
        {
            _context.LogErrores.Add(new DataAccess.Models.LogError()
            {
                Fecha = DateTime.Now,
                Error = error
            });
        }
    }
}
