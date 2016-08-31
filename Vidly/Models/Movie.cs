using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VidlyMovies.Models
{
    public class Movie
    {
        public int ID { get; set; }

        [Required(ErrorMessage ="Please enter movie name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Released Date")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; set ; }

        [Required]
        [Range(1,20)]
        public byte Stock { get; set; }

        public byte AvailableStock { get; set; }

        public MovieGenreTypes MovieGenreTypes { get; set; }

        [Required]
        [Display(Name ="Genre Type")]
        public byte MovieGenreTypesID { get; set; }

        public string  Language { get; set; }
    }
}