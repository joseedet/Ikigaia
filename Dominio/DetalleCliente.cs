using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio
{
    public class DetalleCliente
    {
        [Key]
        public int DetalleClienteId { get; set; }

        public int ClienteId { get; set; }

        [ForeignKey("ClienteId")]
        public Cliente  Cliente { get; set; }

        public int PlainId { get; set; }

        [ForeignKey("PlainId")]
        public Planin  Planin  { get; set; }
    }
}