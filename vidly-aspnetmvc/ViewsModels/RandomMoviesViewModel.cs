using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using vidly_aspnetmvc.Models;
namespace vidly_aspnetmvc.ViewsModels
{
    public class RandomMoviesViewModel
    {
        public Movie Movie { get; set; }
        public List<Customer> Customers { get; set; }
    }
}