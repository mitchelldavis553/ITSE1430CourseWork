using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Movie.Mvc.Controllers
{
    public class MovieController : Controller
    {
        //Verbs:
        //Post/Put modifies data, create and update
        //Delete deletes data
        [HttpGet] // Retrieval of data, NEVER MODIFIES DATA, SHOULD ONLY RETRIEVE
        public ActionResult Index()
        {
            return View();
        }
    }
}