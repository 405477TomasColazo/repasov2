using System.ComponentModel.DataAnnotations;

namespace Library.Domain
{
    public class Libro
    {
        [Key]
        public string Isbn { get; set; }
        public string Titulo { get; set; }
        public Autor Autor { get; set; }
        public DateTime FechaDePublicacion { get; set; }
        public Genero Genero { get; set; }
    }
}
