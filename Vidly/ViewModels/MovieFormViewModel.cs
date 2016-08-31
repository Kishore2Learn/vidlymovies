using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VidlyMovies.Models;

namespace VidlyMovies.ViewModels
{
    public class MovieFormViewModel
    {
        public int? ID { get; set; }

        [Required(ErrorMessage = "Please enter movie name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Released Date")]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        [Display(Name = "Date Added")]
        public DateTime? DateAdded { get; set; }

        [Required]
        [Range(1, 20)]
        public byte? Stock { get; set; }

        [Required]
        [Range(1, 20)]
        [Compare("Stock")]
        [Display(Name ="Confirm Stock")]
        public byte? StockVerify { get; set; }

        [Required]
        [Display(Name = "Genre Type")]
        public byte? MovieGenreTypesID { get; set; }

        [Required]
        public string Language { get; set; }

        public IEnumerable<MovieGenreTypes> MovieGenreTypes { get; set; }
        public IEnumerable<string> Languages { get; set; }

        public MovieFormViewModel()
        {
            ID = 0;
        }

        public MovieFormViewModel(Movie movie)
        {
            ID = movie.ID;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            DateAdded = movie.DateAdded;
            Stock = movie.Stock;
            StockVerify = movie.Stock;
            MovieGenreTypesID = movie.MovieGenreTypesID;
            Language = movie.Language;
        }

        public string Title
        {
            get { return (ID == 0 ? "New Movie" : "Edit Movie "); }
        }
    }
}