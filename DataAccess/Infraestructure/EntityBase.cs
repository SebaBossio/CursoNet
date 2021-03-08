using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccess.Infraestructure
{
    public abstract class EntityBase
    {
        [Key]
        public Guid Id { get; set; }
    }
}
