using Inventario.Api.Data;
using Inventario.Api.DTOs;
using Inventario.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Inventario.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExistenciasController : ControllerBase
    {
        private readonly InventarioDbContext _context;

        public ExistenciasController(InventarioDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Existencia>>> GetExistencias()
        {
            var existencias = await _context.Existencias.AsNoTracking().ToListAsync();
            return Ok(existencias);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Existencia>> GetExistencia(int id)
        {
            var existencia = await _context.Existencias.AsNoTracking().FirstOrDefaultAsync(e => e.IdExistencia == id);
            if (existencia == null) return NotFound();
            return Ok(existencia);
        }

        [HttpPost]
        public async Task<ActionResult<Existencia>> CreateExistencia(ExistenciaDto dto)
        {
            var existencia = new Existencia
            {
                IdProducto = dto.IdProducto,
                IdBodega = dto.IdBodega,
                Stock = dto.Stock
            };

            _context.Existencias.Add(existencia);
            await _context.SaveChangesAsync();
            return Ok(existencia);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateExistencia(int id, ExistenciaDto dto)
        {
            var existencia = await _context.Existencias.FindAsync(id);
            if (existencia == null) return NotFound();

            existencia.IdProducto = dto.IdProducto;
            existencia.IdBodega = dto.IdBodega;
            existencia.Stock = dto.Stock;

            _context.Entry(existencia).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExistencia(int id)
        {
            var existencia = await _context.Existencias.FindAsync(id);
            if (existencia == null) return NotFound();
            _context.Existencias.Remove(existencia);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
