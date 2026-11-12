using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventario.Api.Models
{
    [Table("Existencia")]
    public class Existencia
    {
        [Key]
        public int IdExistencia { get; set; }

        public int IdProducto { get; set; }

        public int IdBodega { get; set; }

        public int Stock { get; set; } = 0;
    }
}
