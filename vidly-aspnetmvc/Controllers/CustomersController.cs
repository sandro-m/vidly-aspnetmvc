using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vidly_aspnetmvc.Models;

namespace vidly_aspnetmvc.Controllers
{
    public class CustomersController : Controller
    {
        List<Customer> list = new List<Customer>
        {
            new Customer { Id = 1, Name = "John" },
            new Customer { Id = 2, Name = "Anna" },
            new Customer { Id = 3, Name = "Reinner" }
        };
        // GET: Customers
        public ActionResult Index()
        {
            return View(list);
        }
        public ActionResult Details(int id)
        {
            var model = list.FirstOrDefault(o => o.Id == id);
            return View(model);
        }
    }
}