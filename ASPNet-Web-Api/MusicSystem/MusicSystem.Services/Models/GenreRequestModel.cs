﻿namespace MusicSystem.Services.Models
{
    using System.ComponentModel.DataAnnotations;

    public class GenreRequestModel
    {
        [Required]
        public string Name { get; set; }
    }
}