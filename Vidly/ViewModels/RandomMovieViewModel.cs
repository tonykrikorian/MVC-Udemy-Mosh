using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class RandomMovieViewModel
    {
        public Movie Movie { get; set; }
        /// <summary>
        /// List of Customers
        /// </summary>
        public ICollection<Customer> Customers { get; set; }

        public Customer Customer { get; set; }
    }
}