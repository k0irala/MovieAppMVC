using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Identity.Client;

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
        public string MovieFileName { get; set; }
        public string MovieFilePath { get; set; }
        [NotMapped]
        public IFormFile MovieFile { get; set; }
        public GenreViewModel? genre { get; set; }

    }

}
