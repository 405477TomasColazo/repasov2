namespace Library.Dtos
{
    public class LibroDto
    {
        public string Isbn { get; set; }
        public string Titulo { get; set; }
        public AutorDto Autor { get; set; }
        public DateTime FechaDePublicacion { get; set; }
        public GeneroDto Genero { get; set; }
    }
}
