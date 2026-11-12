using Catalogo.Api.Data;
using Catalogo.Api.DTOs;
using Catalogo.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Catalogo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcasController : ControllerBase
    {
        private readonly CatalogoDbContext _context;

        public MarcasController(CatalogoDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Marca>>> GetMarcas()
        {
            var marcas = await _context.Marcas.AsNoTracking().ToListAsync();
            return Ok(marcas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Marca>> GetMarca(int id)
        {
            var marca = await _context.Marcas.AsNoTracking().FirstOrDefaultAsync(m => m.IdMarca == id);
            if (marca == null) return NotFound();
            return Ok(marca);
        }

        [HttpPost]
        public async Task<ActionResult<Marca>> CreateMarca(MarcaDto dto)
        {
            var marca = new Marca
            {
                Nombre = dto.Nombre,
                PaisOrigen = dto.PaisOrigen
            };

            _context.Marcas.Add(marca);
            await _context.SaveChangesAsync();
            return Ok(marca);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMarca(int id, MarcaDto dto)
        {
            var marca = await _context.Marcas.FindAsync(id);
            if (marca == null) return NotFound();

            marca.Nombre = dto.Nombre;
            marca.PaisOrigen = dto.PaisOrigen;

            _context.Entry(marca).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMarca(int id)
        {
            var marca = await _context.Marcas.FindAsync(id);
            if (marca == null) return NotFound();
            _context.Marcas.Remove(marca);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
