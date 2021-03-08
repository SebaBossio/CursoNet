using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class ExamenFinalContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("data source=localhost;initial catalog=ExamenFinal;Integrated Security=true;");
        }

        public virtual DbSet<Libro> Libros { get; set; }
        public virtual DbSet<Stock> Stocks { get; set; }
        public virtual DbSet<HistorialMovimientosStock> HistorialMovimientosStocks { get; set; }
        public virtual DbSet<LogError> LogErrores { get; set; }
    }
}
