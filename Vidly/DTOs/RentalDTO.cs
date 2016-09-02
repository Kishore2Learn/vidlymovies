using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VidlyMovies.Models;

namespace VidlyMovies.DTOs
{
    public class RentalDTO
    {
        public int Id { get; set; }

        [Required]
        public CustomerDTO Customer { get; set; }

        [Required]
        public MovieDTO Movie { get; set; }

        public DateTime DateRented { get; set; }

        public DateTime? DateReturned { get; set; }

        public string RentedBy { get; set; }

        public string ReceivedBy { get; set; }

        public string DateRentedForDisplay { get { return DateRented.Date.ToString("dd MMM yyyy");} }

        public string DateReturnedForDisplay { get { return DateReturned.GetValueOrDefault().Date.ToString("dd MMM yyyy"); } }
    }
}