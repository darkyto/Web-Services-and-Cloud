namespace MusicSystem.Services.Models
{
    using System.ComponentModel.DataAnnotations;

    public class SongRequestModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public int GenreId { get; set; }
    }
}