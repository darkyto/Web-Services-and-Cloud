namespace MusicSystem.Services.Models
{
    using System.ComponentModel.DataAnnotations;

    public class AlbumRequestModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public int ProducerId { get; set; }

        [Required]
        public int[] SongIds { get; set; }

        [Required]
        public int[] ArtistIds { get; set; }
    }
}