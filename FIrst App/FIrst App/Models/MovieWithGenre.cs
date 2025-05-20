using System.ComponentModel.DataAnnotations;

namespace FIrst_App.Models
{
    public class MovieWithGenre
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int GenreId { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string MovieFilePath { get; set; }
        [Required]
        public int Rating { get; set; }
        public string GenreName { get; set; }


    }
}
