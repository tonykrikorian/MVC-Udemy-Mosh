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

        private List<Customer> customers;
        private RandomMovieViewModel viewModel;

        public CustomersController()
        {
            this.customers = new List<Customer>()
            {
                new Customer(){ Id=1, Name ="Tony Krikorian" },
                new Customer(){ Id=2, Name ="Tarin Gonzales" },
                new Customer(){ Id=3, Name ="Claudio Altamirano"}
            };

            this.viewModel = new RandomMovieViewModel();
        }
        // Index
        public ActionResult Index()
        {

            viewModel.Customers = customers;
            return View(viewModel);
        }


        [Route("customers/details/{id:regex(\\d)}")]
        public ActionResult Details(int id)
        {
            var customer = customers.Where(x => x.Id == id).Select(x => x).SingleOrDefault();
            viewModel.Customer = customer;
            return View(viewModel);
        }
    }
}