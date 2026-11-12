using System.ComponentModel.DataAnnotations;

namespace Catalogo.Api.DTOs
{
    public class CategoriaDto
    {
        [Required]
        public string Nombre { get; set; } = string.Empty;
        public string? Descripcion { get; set; }
    }

    public class MarcaDto
    {
        [Required]
        public string Nombre { get; set; } = string.Empty;
        public string? PaisOrigen { get; set; }
    }

    public class ProductoDto
    {
        [Required]
        public int IdCategoria { get; set; }

        [Required]
        public int IdMarca { get; set; }

        [Required]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        public string SKU { get; set; } = string.Empty;

        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor a 0")]
        public decimal Precio { get; set; }

        public bool Estado { get; set; } = true;
    }
}
