using BibliotecaBitwise.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiBibliotecaSourcestree.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public LibroController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Libro>>> ObtenerTodos()
        {
            var libros = await _context.Libros.ToListAsync();
            return Ok(libros);
        }
        [HttpGet("{id]")]
        public async Task<ActionResult<Libro>> ObtenerPorId(int id)
        {
            var libros = await _context.Libros.FirstOrDefaultAsync(l => l.Id == id);
            
            if (libros == null)
                return NotFound();

            return Ok(libros);
        }
    }
}
