using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vidly_aspnetmvc.Models;
using vidly_aspnetmvc.ViewsModels;

namespace vidly_aspnetmvc.Controllers
{
    public class MoviesController : Controller
    {
        List<Movie> list = new List<Movie>
        {
            new Movie { Id = 1 , Name = "Shrek" },
            new Movie { Id = 1 , Name = "Rush Hour 2" },
            new Movie { Id = 1 , Name = "Mission Impossible" }
        };
        public ActionResult Index()
        {
            return View(list);
        }
        public ActionResult Details(int id)
        {
            var model = list.FirstOrDefault(o => o.Id == id);
            return View(model);
        }
        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie()
            {
                Id = 1,
                Name = "Shrek"
            };
            var customers = new List<Customer>
            {
                new Customer { Id = 1, Name = "Philip" },
                new Customer { Id = 2, Name = "Trevor" }
            };

            var viewModel = new RandomMoviesViewModel()
            {
                Movie = movie,
                Customers = customers
            };
            return View(viewModel);
        }
        public ActionResult Edit(int id)
        {
            return Content("id: " + id);
        }
        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1, 12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}