namespace MusicSystem.Services.Models
{
    using System.ComponentModel.DataAnnotations;

    public class ProducerRequestModel
    {
        [Required]
        public string Name { get; set; }
    }
}