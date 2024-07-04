using Library.Domain;
using Microsoft.EntityFrameworkCore;

namespace Library.Context
{
    public class LibraryDBContext : DbContext
    {
        public LibraryDBContext(DbContextOptions options):base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Genero>().HasData(
                new Genero { Id = 1, Nombre = "Fantasia"},
                new Genero { Id = 2, Nombre = "Romance"},
                new Genero { Id = 3, Nombre = "Historico"},
                new Genero { Id = 4, Nombre = "Misterio"});
        }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Libro> Libros { get; set; }
    }
}
