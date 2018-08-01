using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        private ApplicationDbContext _context;
        private RandomMovieViewModel viewModel;

        public CustomersController()
        {
            this.viewModel = new RandomMovieViewModel();
            this._context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // Index
        public ActionResult Index()
        {

            viewModel.Customers = _context.Customer.ToList();
            return View(viewModel);
        }


        [Route("customers/details/{id:regex(\\d)}")]
        public ActionResult Details(int id)
        {
            var customer = _context.Customer.Where(x => x.Id == id).Select(x => x).SingleOrDefault();
            viewModel.Customer = customer;
            return View(viewModel);
        }
    }
}