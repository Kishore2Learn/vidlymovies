using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VidlyMovies.Models;
using VidlyMovies.DTOs;

namespace VidlyMovies.ViewModels
{
    public class RentalViewModel
    {
        public MovieDTO Movie { get; set; }
        public IEnumerable<RentalDTO> Rentals { get; set; }
    }
}