using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VidlyMovies.DTOs
{
    public class MovieGenreTypeDTO
    {
        public byte ID { get; set; }
        [Required]
        [StringLength(255)]
        public string GenreType { get; set; }
    }
}