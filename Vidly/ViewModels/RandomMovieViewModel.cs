using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VidlyMovies.Models;

namespace VidlyMovies.ViewModels
{
    public class RandomMovieViewModel
    {
        public Movie Movie { get; set; }
        public IEnumerable<Customer> Customers { get; set; } 
    }
}