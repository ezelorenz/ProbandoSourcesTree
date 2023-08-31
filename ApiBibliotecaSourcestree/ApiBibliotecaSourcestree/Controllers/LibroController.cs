using ApiBibliotecaSourcestree.DAL.Interfaces;
using ApiBibliotecaSourcestree.DTO;
using AutoMapper;
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
        private readonly IGenericRepository<Libro> _repository;
        private readonly IMapper _mapper;

        public LibroController(IGenericRepository<Libro> repositor,
                                IMapper mapper)
        {
            _mapper = mapper;
            _repository = repositor;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<LibroDto>>> ObtenerTodos()
        {
            var libros = await _repository.ObtenerTodos();
            var librosDTO = _mapper.Map<IEnumerable<LibroDto>>(libros);
            return Ok(librosDTO);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Eliminar(int id)
        {
            var libroDesdeRepo = await _repository.Obtener(id);
            if (libroDesdeRepo == null)
                return NotFound();

            var resultado = await _repository.Eliminar(id);
            if (resultado)
                return NoContent();

            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Actualizar(int id, LibroDto libroCreacionDTO)
        {
            var libroDesdeRepo = await _repository.Obtener(id);
            if (libroDesdeRepo == null)
                return NotFound();

            _mapper.Map(libroCreacionDTO, libroDesdeRepo);
            var resultado = await _repository.Actualizar(libroDesdeRepo);
            if (resultado)
                return NoContent();

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Eliminar(int id)
        {
            var libroDesdeRepo = await _repository.Obtener(id);
            if (libroDesdeRepo == null)
                return NotFound();

            var resultado = await _repository.Eliminar(id);
            if (resultado)
                return NoContent();

            return BadRequest();
        }
    }
}
