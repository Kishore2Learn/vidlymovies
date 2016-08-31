using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyMovies.Models;
using VidlyMovies.ViewModels;
using PagedList;
using System.Globalization;
using AutoMapper;
using VidlyMovies.DTOs;

namespace VidlyMovies.Controllers
{
    public class MoviesController : Controller
    {

        public ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        private IEnumerable<Customer> GetCustomers(int MovieID)
        {
            return new List<Customer>
            {
                new Customer { Name = "Customer 1"},
                new Customer { Name= "Customer 2" }
            };
        }

        private IEnumerable<string> GetLanguages()
        {
            IEnumerable<CultureInfo> cinfo = CultureInfo.GetCultures(CultureTypes.AllCultures & ~CultureTypes.NeutralCultures);
            List<string> languages=new List<string>();
            foreach (var item in cinfo)
            {
                languages.Add(item.DisplayName); 
            }
            return languages;
        }

        public  ActionResult Index(int? page)
        {
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(_context.Movies
                .Include(c => c.MovieGenreTypes)
                .OrderBy(c => c.ID)
                .ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Details(int? id)
        {
            Movie selectedMovie = null;
            if (id.HasValue)
            {
                
                var movieID = id.GetValueOrDefault(0);
                selectedMovie = _context.Movies.Include(c => c.MovieGenreTypes).SingleOrDefault(c => c.ID == movieID);
                if (selectedMovie != null)
                {
                    ViewBag.ContainData = "1";
                    var rentalsQuery = _context.Rentals
                        .Include(r => r.Customer)
                        .Where(r => r.Movie.ID == id);

                    var rentalsDTO = rentalsQuery.Select(Mapper.Map<Rental, RentalDTO>).ToList();

                    var rentalViewModel = new RentalViewModel() {
                        Movie = Mapper.Map<Movie,MovieDTO>(selectedMovie),
                        Rentals = rentalsDTO
                    };
                    return View(rentalViewModel);
                }
                else
                {
                    ViewBag.ContainData = "0";
                    ViewBag.Description = "Movie details for Movie ID " + movieID + " not found.";
                    return View();
                }
            }
            else
            {
                ViewBag.ContainData = "2";
                ViewBag.Description = "Please select any movie to view details.";
                return View();
            }
        }

        public ActionResult Edit(int? id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.ID == id);
            var newMovieFormViewModel = new MovieFormViewModel(movie)
            {
                MovieGenreTypes = _context.MovieGenreTypes.ToList(),
                Languages = GetLanguages()
            };
            ViewBag.New = false;
            return View("MovieForm", newMovieFormViewModel);
        }

        public ActionResult New()
        {
            var newMovieFormViewModel = new MovieFormViewModel()
            {
                MovieGenreTypes = _context.MovieGenreTypes.ToList(),
                Languages = GetLanguages()

            };
            ViewBag.New = true;
            return View("MovieForm", newMovieFormViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    MovieGenreTypes = _context.MovieGenreTypes.ToList(),
                    Languages=GetLanguages()

                };
                ViewBag.New = movie.ID == 0;
                return View("MovieForm", viewModel);
            }

            if (movie.ID == 0)
            {
                ViewBag.Description = "New Movie Details Saved Successfully For ";
                movie.AvailableStock = movie.Stock;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieFromDB = _context.Movies.SingleOrDefault(c => c.ID == movie.ID);
                movieFromDB.Name = movie.Name;
                movieFromDB.MovieGenreTypesID  = movie.MovieGenreTypesID;
                movieFromDB.Language = movie.Language;
                movieFromDB.ReleaseDate = movie.ReleaseDate;
                movieFromDB.DateAdded = movie.DateAdded;
                movieFromDB.Stock = movie.Stock;
                ViewBag.Description = "Movie Details Updated Successfully For ";
            }
            _context.SaveChanges();

            ViewBag.ContainData = "1";
            return View("UpdatedDetails", movie);
        }

        public ActionResult Delete(int? id)
        {
            if (id.HasValue)
            {
                var movieID = id.GetValueOrDefault(0);
                var selectedMovie = _context.Movies.Single(c => c.ID == movieID);
                if (selectedMovie != null)
                {
                    ViewBag.ContainData = "2";
                    _context.Movies.Remove(selectedMovie);
                    _context.SaveChanges();
                    ViewBag.Description = selectedMovie.Name + " Movie deleted";
                    return View("UpdatedDetails");
                }
                else
                {

                    ViewBag.ContainData = "2";
                    ViewBag.Description = "Movie details for Movie ID " + movieID + " not found.";
                    return View("UpdatedDetails");
                }
            }
            else
            {
                ViewBag.ContainData = "2";
                ViewBag.Description = "Please select any Movie to delete.";
                return View("UpdatedDetails");
            }
        }

        [Route("movies/Random")]
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Kabali" };
            // not a good way..need to use correct magic property in view
            //ViewData["Movie"] = movie;

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = GetCustomers(0)
            };
            return View(viewModel);
        }
        [Route("movies/released/{year:regex(201[1-6])}/{month:range(1,12)}")]
        public ActionResult Released(int year,int month)
        {
            return Content(year + "/" + month);
        }
    }
}