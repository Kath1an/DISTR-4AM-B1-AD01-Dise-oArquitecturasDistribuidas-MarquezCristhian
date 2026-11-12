using Inventario.Api.Data;
using Inventario.Api.DTOs;
using Inventario.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Inventario.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BodegasController : ControllerBase
    {
        private readonly InventarioDbContext _context;

        public BodegasController(InventarioDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bodega>>> GetBodegas()
        {
            var bodegas = await _context.Bodegas.AsNoTracking().ToListAsync();
            return Ok(bodegas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Bodega>> GetBodega(int id)
        {
            var bodega = await _context.Bodegas.AsNoTracking().FirstOrDefaultAsync(b => b.IdBodega == id);
            if (bodega == null) return NotFound();
            return Ok(bodega);
        }

        [HttpPost]
        public async Task<ActionResult<Bodega>> CreateBodega(BodegaDto dto)
        {
            var bodega = new Bodega
            {
                Nombre = dto.Nombre,
                Ciudad = dto.Ciudad,
                Direccion = dto.Direccion
            };

            _context.Bodegas.Add(bodega);
            await _context.SaveChangesAsync();
            return Ok(bodega);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBodega(int id, BodegaDto dto)
        {
            var bodega = await _context.Bodegas.FindAsync(id);
            if (bodega == null) return NotFound();

            bodega.Nombre = dto.Nombre;
            bodega.Ciudad = dto.Ciudad;
            bodega.Direccion = dto.Direccion;

            _context.Entry(bodega).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBodega(int id)
        {
            var bodega = await _context.Bodegas.FindAsync(id);
            if (bodega == null) return NotFound();
            _context.Bodegas.Remove(bodega);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
