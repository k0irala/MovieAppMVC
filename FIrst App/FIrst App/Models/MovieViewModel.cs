using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIrst_App.Models
{
    public class MovieViewModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string MovieFileName { get; set; }
        public string MovieFilePath { get; set; }

        [NotMapped]
        public IFormFile MoviePoster { get; set; }
        [Required]
        public int GenreId { get; set; }
        public int Rating { get; set; }
        public GenreViewModel? genre { get; set; }

    }

}
