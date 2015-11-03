namespace MusicSystem.Services.Models
{
    using System.ComponentModel.DataAnnotations;

    public class ArtistRequestModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int CountryId { get; set; }
    }
}