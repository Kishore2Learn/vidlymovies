using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VidlyMovies.Models
{
    public class Rental
    {
        public int Id { get; set; }

        [Required]
        public Customer Customer { get; set; }  

        [Required]
        public Movie Movie{ get; set; }

        public DateTime DateRented { get; set; }

        public DateTime?  DateReturned { get; set; }

        [Required]
        [Display(Name ="Rented By")]
        [StringLength(200)]
        public string RentedBy { get; set; }

        [Display(Name = "Received By")]
        [StringLength(200)]
        public string ReceivedBy { get; set; }
    }
}