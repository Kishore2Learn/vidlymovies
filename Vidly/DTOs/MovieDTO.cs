using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VidlyMovies.Models;

namespace VidlyMovies.DTOs
{
    public class MovieDTO
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Please enter movie name")]
        public string Name { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }

        [Required]
        [Range(1, 20)]
        public byte Stock { get; set; }

        public byte AvailableStock { get; set; }

        public MovieGenreTypeDTO MovieGenreTypes { get; set; }

        [Required]
        public byte MovieGenreTypesID { get; set; }

        public string Language { get; set; }
    }
}