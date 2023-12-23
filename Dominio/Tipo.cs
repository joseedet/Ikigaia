using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio
{
    public class Tipo
    {
        [Key]
        public int TipoId { get; set; }
        public required string Nombre { get; set; }

        ICollection<DetalleCliente> DetalleClientesLink {get;set;}
    }
}