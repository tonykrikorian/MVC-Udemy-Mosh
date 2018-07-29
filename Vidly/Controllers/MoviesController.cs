﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek" };

            var customers = new List<Customer>()
            {
                new Customer(){ Name ="Customer 1" },
                new Customer(){ Name ="Customer 2" }
            };

            var viewModel = new RandomMovieViewModel()
            {
                 Customers = customers,
                 Movie = movie
            };


            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }

        // movies
        public ActionResult Index(int? page, string sortBy)
        {
            page = page.HasValue ? page : 1;
            sortBy = !string.IsNullOrEmpty(sortBy) ? sortBy : "name";

            return Content(string.Format("pageIndex={0}&sortBy={1}",page,sortBy));
        }

        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year,int month)
        {
            return Content(year +"/" +month);
        }

        [Route("Movies/Movies")]
        public ActionResult GetMovies()
        {
            return View();
        }
    }
}