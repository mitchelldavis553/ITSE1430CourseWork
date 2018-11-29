using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ITSE1430.MovieLib;
using ITSE1430.MovieLib.Sql;
using Movie.Mvc.Models;

namespace Movie.Mvc.Controllers
{
    public class MovieController : Controller
    {
        public MovieController()
        {
            var connString = ConfigurationManager.ConnectionStrings["MovieDatabase"];

            _database = new SqlMovieDatabase(connString.ConnectionString);
        }
        //Verbs:
        //Post/Put modifies data, create and update
        //Delete deletes data
        [HttpGet] // Retrieval of data, NEVER MODIFIES DATA, SHOULD ONLY RETRIEVE
        public ActionResult Index() // Base product page
        {
            var items = _database.GetAll();

            return View(items.Select(i => new MovieModel(i)));
        }

        [HttpGet]
        public ActionResult Create()
        {
            var model = new MovieModel();

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(MovieModel model)
        {
            if (ModelState.IsValid)
            {
                var item = model.ToDomain();
                try
                {
                    _database.Add(item);
                } catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                };

                return RedirectToAction("Index");
            };

            return View(model);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var item = _database.GetAll().FirstOrDefault(i => i.Id == id);

            return View(new MovieModel(item));
        }

        [HttpPost]
        public ActionResult Edit( MovieModel model )
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var item = model.ToDomain();

                    var existing = _database.GetAll().FirstOrDefault(i => i.Id == model.Id);

                    _database.Edit(existing.Name, item);
                } catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                };

                return RedirectToAction("Index");
            };

            return View(model);
        }

        private readonly IMovieDatabase _database;
    }
}