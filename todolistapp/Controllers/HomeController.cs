using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using todolistapp.Models;

namespace todolistapp.Controllers
{
    public class HomeController : Controller
    {
        todoEntities _db;
        public HomeController()
        {
            _db = new todoEntities();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List(int id = 0)
        {
            List<task> tasks;

            if (id == 0)
            {
                tasks = _db.task.ToList();
            }
            else
            {
                tasks = _db.task.Where(a => a.id == id).ToList();
            }
            return View(tasks);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(task t)
        {
            _db.task.Add(t);

            try
            {
                int result = _db.SaveChanges();
                if (result > 0)
                {
                    return RedirectToAction("List");
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                ViewBag.IsSucces = false;

                return View();
            }
        }

        public ActionResult Delete(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("List");
            }

            task t = _db.task.Where(a => a.id == id).SingleOrDefault();

            if (t == null)
            {
                return RedirectToAction("List");
            }
            return View(t);
        }

        [HttpPost]
        public ActionResult Delete(task t)
        {
            task deleted = _db.task.Find(t.id);
            _db.Set<task>().Remove(deleted);
            _db.SaveChanges();
            return RedirectToAction("List");

        }

        public ActionResult Update(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("List");
            }

            task t = _db.task.Where(a => a.id == id).SingleOrDefault();
            if (t == null)
            {
                return RedirectToAction("List");
            }
            return View(t);
        }

        [HttpPost]
        public ActionResult Update(task t)
        {
            _db.Entry(t).State = System.Data.Entity.EntityState.Modified;

            try
            {
                int result = _db.SaveChanges();
                if (result > 0)
                {
                    return RedirectToAction("List");
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                ViewBag.IsSucces = false;

                return View(t);
            }

        }
    }
}