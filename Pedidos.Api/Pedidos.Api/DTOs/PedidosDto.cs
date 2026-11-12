using System.ComponentModel.DataAnnotations;

namespace Pedidos.Api.DTOs
{
    public class ClienteDto
    {
        [Required]
        public string Nombres { get; set; } = string.Empty;

        [Required]
        public string Cedula { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Correo { get; set; } = string.Empty;
    }

    public class PedidoDto
    {
        [Required]
        public int IdCliente { get; set; }

        public string Estado { get; set; } = "PENDIENTE";
    }

    public class DetallePedidoDto
    {
        [Required]
        public int IdPedido { get; set; }

        [Required]
        public int IdProducto { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor a 0")]
        public int Cantidad { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor a 0")]
        public decimal PrecioUnitario { get; set; }
    }
}
