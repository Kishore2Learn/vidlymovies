using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VidlyMovies.DTOs;
using VidlyMovies.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Web;
using AutoMapper;

namespace VidlyMovies.Controllers.API
{
    public class RentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public RentalsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        [HttpGet]
        public IHttpActionResult GetRentals(string query=null)
        {
            string customerName="", movieName="";

            query = string.IsNullOrEmpty(query) ? "" : query;

            var moviesQuery = _context.Rentals
                .Include(r => r.Customer)
                .Include(r => r.Movie)
                .Where(r => r.DateReturned == null);

            if (query.Contains("Customer"))
            {
                customerName = query.Split('-')[1];
                var rentals = from r in moviesQuery
                              where r.Customer.Name.Contains(customerName) 
                              select r;

                return Ok(rentals
                    .ToList()
                    .Select(Mapper.Map<Rental, RentalDTO>));

            }
            else if (query.Contains("Movie"))
            {
                movieName = query.Split('-')[1];
                var rentals = from r in moviesQuery
                              where r.Movie.Name.Contains(movieName)
                              select r;

                return Ok(rentals
                    .ToList()
                    .Select(Mapper.Map<Rental, RentalDTO>));

            }
            else
            {
                return Ok(moviesQuery
                    .ToList()
                    .Select(Mapper.Map<Rental, RentalDTO>));
            }
        }

        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDTO newRental)
        {
            var customer = _context.Customers
                .Single(c => c.ID == newRental.CustomerID);

            var movies = _context.Movies.Where(
                m => newRental.MovieIDs.Contains(m.ID)).ToList();

            var userName = User.Identity.GetUserName();

            foreach (Movie movie in movies)
            {
                if (movie.AvailableStock == 0)
                    return BadRequest("One or more selected movie is out of stock");

                movie.AvailableStock--;
                var rental = new Rental()
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now,
                    RentedBy= userName,
                    ReceivedBy =" "
                };

                _context.Rentals.Add(rental);
            }

            _context.SaveChanges();

            return Ok();
        }

        [HttpPut]
        public IHttpActionResult UpdateRental(int id)
        {
            var userName = User.Identity.GetUserName();

            try
            {
                var rental = _context.Rentals
                    .Include(r=>r.Customer)
                    .Include(r=>r.Movie)
                    .Single(r => r.Id == id);

                if (rental == null)
                    return NotFound();

                var movie = _context.Movies.Single(m => m.ID == rental.Movie.ID);
                movie.AvailableStock++;
                rental.DateReturned = DateTime.Now;
                rental.ReceivedBy = userName;
                _context.SaveChanges();
            }
            catch (Exception e )
            {
                throw new HttpException(e.Message);
            }

            return Ok();
        }
    }
}
