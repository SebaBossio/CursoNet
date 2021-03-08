using DataAccess.Infraestructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccess.Models
{
    public class LogError : EntityBase
    {
        [Column(TypeName = "DATETIME")]
        public DateTime Fecha { get; set; }
        [Column(TypeName = "VARCHAR(MAX)")]
        public string Error { get; set; }
    }
}
