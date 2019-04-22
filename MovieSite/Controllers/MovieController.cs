using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieSite.Models;

namespace MovieSite.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie/Index
        public ActionResult Index()
        {
            using (DBModels db = new DBModels())
            {
                return View(db.Movies.ToList());
            }
               
        }

        // GET: Movie/Details/5
        public ActionResult Details(int id)
        {
            using (DBModels db = new DBModels())
            {
                return View(db.Movies.Where(x => x.Id == id).FirstOrDefault()); ;
            }
        }

        // GET: Movie/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movie/Create
        [HttpPost]
        public ActionResult Create(Movies movies)
        {
            try
            {
                // TODO: Add insert logic here
                using (DBModels db = new DBModels())
                {
                    db.Movies.Add(movies);
                    db.SaveChanges();
                }

                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Movie/Edit/5
        public ActionResult Edit(int id)
        {
            using (DBModels db = new DBModels())
            {
                return View(db.Movies.Where(x => x.Id == id).FirstOrDefault()); ;
            }
        }

        // POST: Movie/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Movies movies)
        {
            try
            {
                // TODO: Add update logic here
                using (DBModels db = new DBModels())
                {
                    db.Entry(movies).State = EntityState.Modified;
                    db.SaveChanges();
                }

                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Movie/Delete/5
        public ActionResult Delete(int id)
        {
            using (DBModels db = new DBModels())
            {
                return View(db.Movies.Where(x => x.Id == id).FirstOrDefault()); ;
            }
        }

        // POST: Movie/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Movies movies)
        {
            try
            {
                // TODO: Add delete logic here
                using (DBModels db = new DBModels())
                {
                    movies = db.Movies.Where(x => x.Id == id).FirstOrDefault();
                    db.Movies.Remove(movies);
                    db.SaveChanges();
                }
                   
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
