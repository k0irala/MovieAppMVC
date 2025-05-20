using FIrst_App.Models;
using Microsoft.EntityFrameworkCore;

namespace FIrst_App.Data
{
    public class MovieContext : DbContext {

    public MovieContext(DbContextOptions<MovieContext> options) : base(options) {
        }
        public DbSet<MovieViewModel> movie { get; set; }
        public DbSet<GenreViewModel> genre { get; set; }



        public DbSet<MovieWithGenre> MovieWithGenre {get; set; }
    }
}
