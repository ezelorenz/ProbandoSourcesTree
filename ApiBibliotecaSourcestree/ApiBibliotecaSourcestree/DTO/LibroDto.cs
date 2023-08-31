namespace ApiBibliotecaSourcestree.DTO
{
    public class LibroDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = null!;
        public bool ParaPrestar { get; set; }
        public DateTime FechaLanzamiento { get; set; }
        public string NombreAutor { get; set; }
        public string NombreGenero { get; set; }
        public HashSet<ListaComentariosDTO> Comentarios { get; set; } = new HashSet<ListaComentariosDTO>();
    }
}
