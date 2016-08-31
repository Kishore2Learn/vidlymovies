using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VidlyMovies.DTOs;
using VidlyMovies.Models;

namespace VidlyMovies.Controllers.API
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public IEnumerable<MovieDTO> GetMovies(string query=null,bool all=false)
        {
            var moviesQuery = _context.Movies
                .Include(m => m.MovieGenreTypes)
                .Where(m => m.AvailableStock > (all ? -1:0));

            if (!string.IsNullOrWhiteSpace(query))
            {
                moviesQuery = moviesQuery.Where(m => m.Name.Contains(query));
            }

            return moviesQuery
                .ToList() 
                .Select(Mapper.Map<Movie, MovieDTO>);
        }
    }
}
