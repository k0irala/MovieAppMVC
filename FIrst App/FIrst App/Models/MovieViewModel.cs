using System.ComponentModel.DataAnnotations;

namespace FIrst_App.Models
{
    public class MovieViewModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public int GenreId { get; set; }
        public int Rating { get; set; }
        public GenreViewModel? genre { get; set; }

    }

}
