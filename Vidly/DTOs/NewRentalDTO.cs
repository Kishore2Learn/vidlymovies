using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VidlyMovies.Models;

namespace VidlyMovies.DTOs
{
    public class NewRentalDTO
    {
        public int CustomerID { get; set; }
        public List<int> MovieIDs { get; set; }
    }
}