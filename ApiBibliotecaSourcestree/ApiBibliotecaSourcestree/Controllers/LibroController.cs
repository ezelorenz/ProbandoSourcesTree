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


    }
}
