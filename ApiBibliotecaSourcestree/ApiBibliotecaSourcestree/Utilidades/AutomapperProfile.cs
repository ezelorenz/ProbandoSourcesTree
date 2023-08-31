using ApiBibliotecaSourcestree.DTO;
using AutoMapper;
using BibliotecaBitwise.Models;

namespace ApiBibliotecaSourcestree.Utilidades
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Libro, LibroDto>()
                .ForMember(d => d.NombreAutor, o => o.MapFrom(src => src.Autor.Nombre))
                .ForMember(d => d.NombreGenero, o => o.MapFrom(src => src.Genero.Nombre))
                .ForMember(d => d.FechaLanzamiento,
                opt => opt.MapFrom(o => o.FechaLanzamiento.ToString("dd/MM/yyyy")));
        }
    }
}
