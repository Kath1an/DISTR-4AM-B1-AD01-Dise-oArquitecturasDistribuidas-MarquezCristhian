using System.ComponentModel.DataAnnotations;

namespace Inventario.Api.DTOs
{
    public class BodegaDto
    {
        [Required]
        public string Nombre { get; set; } = string.Empty;
        public string? Ciudad { get; set; }
        public string? Direccion { get; set; }
    }

    public class ExistenciaDto
    {
        [Required]
        public int IdProducto { get; set; }

        [Required]
        public int IdBodega { get; set; }

        [Range(0, int.MaxValue)]
        public int Stock { get; set; }
    }

    public class MovimientoInventarioDto
    {
        [Required]
        public int IdProducto { get; set; }

        [Required]
        public int IdBodega { get; set; }

        [Required]
        public string Tipo { get; set; } = string.Empty;

        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor a 0")]
        public int Cantidad { get; set; }
    }

    public class ReservaStockDto
    {
        [Required]
        public int IdProducto { get; set; }

        [Required]
        public int IdBodega { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor a 0")]
        public int Cantidad { get; set; }

        public string Estado { get; set; } = "PENDIENTE";
    }
}
