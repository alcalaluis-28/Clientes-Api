using ClientesApi.Data;
using ClienteApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClientesApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/productos -> Listar todos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producto>>> Listar()
        {
            var productos = await _context.Productos.AsNoTracking().ToListAsync();
            return Ok(productos);
        }

        // GET: api/productos/1 -> Buscar por ID
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Producto>> ObtenerPorId(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound(new { mensaje = $"No existe producto con ID: {id}" });
            }
            return Ok(producto);
        }

        // POST: api/productos -> Crear producto
        [HttpPost]
        public async Task<ActionResult<Producto>> Registrar([FromBody] Producto producto)
        {
            producto.Id = 0; // Evita envío manual de ID

            // Validación: evitar registrar mismo número de serie si no es nulo
            if (!string.IsNullOrEmpty(producto.Numserie) &&
                await _context.Productos.AnyAsync(p => p.Numserie == producto.Numserie))
            {
                return Conflict(new { mensaje = "Ya existe un producto con ese número de serie" });
            }

            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(ObtenerPorId), new { id = producto.Id }, producto);
        }

        // PUT: api/productos/1 -> Actualizar producto
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Actualizar(int id, [FromBody] Producto producto)
        {
            if (id != producto.Id)
            {
                return BadRequest(new { mensaje = "El ID de la ruta no coincide con el ID del cuerpo" });
            }

            var existente = await _context.Productos.FindAsync(id);
            if (existente == null)
            {
                return NotFound(new { mensaje = $"No existe producto con ID: {id}" });
            }

            // Validar que el número de serie no pertenezca a otro producto
            if (!string.IsNullOrEmpty(producto.Numserie) &&
                await _context.Productos.AnyAsync(p => p.Numserie == producto.Numserie && p.Id != id))
            {
                return Conflict(new { mensaje = "Ya existe otro producto con ese número de serie" });
            }

            // Actualizar campos
            existente.Nombre = producto.Nombre;
            existente.Descripcion = producto.Descripcion;
            existente.Precio = producto.Precio;
            existente.Garantia = producto.Garantia;
            existente.Numserie = producto.Numserie;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/productos/1 -> Eliminar producto
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound(new { mensaje = $"No existe producto con ID: {id}" });
            }

            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}