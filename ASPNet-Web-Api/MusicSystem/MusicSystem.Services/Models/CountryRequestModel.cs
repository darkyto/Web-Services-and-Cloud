namespace MusicSystem.Services.Models
{
    using System.ComponentModel.DataAnnotations;

    public class CountryRequestModel
    {
        [Required]
        public string Name { get; set; }
    }
}