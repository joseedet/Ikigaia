using System.ComponentModel.DataAnnotations;

namespace Dominio
{
    public class Cliente
    {
        [Key]
        public int ClienteId { get; set; }
        public required string Dni { get; set; }
        public required string Pasaporte { get; set; }
        public required string Nombre { get; set; }
        public required string Apellidos { get; set; }
        public required string Direccion { get; set; }
        public required string Poblacion { get; set; }
        public required string CodPostal { get; set; }
        public required string Provincia { get; set; }
        public required string Telefono { get; set; }
        public required string Correo { get; set; }
        public string Observaciones { get; set; }

        ICollection<DetalleCliente> ListaDetalleCliente {get;set;}

    }
}