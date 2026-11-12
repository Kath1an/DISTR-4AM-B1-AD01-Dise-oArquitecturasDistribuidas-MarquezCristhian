using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventario.Api.Models
{
    [Table("Bodega")]
    public class Bodega
    {
        [Key]
        public int IdBodega { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public string? Ciudad { get; set; }

        public string? Direccion { get; set; }
    }
}
