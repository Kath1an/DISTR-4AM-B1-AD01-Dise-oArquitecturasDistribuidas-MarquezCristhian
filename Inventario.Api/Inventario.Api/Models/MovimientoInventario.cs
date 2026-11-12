using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventario.Api.Models
{
    [Table("MovimientoInventario")]
    public class MovimientoInventario
    {
        [Key]
        public int IdMovimiento { get; set; }

        public int IdProducto { get; set; }

        public int IdBodega { get; set; }

        public string Tipo { get; set; } = string.Empty;

        public int Cantidad { get; set; }

        public DateTime Fecha { get; set; } = DateTime.Now;
    }
}
