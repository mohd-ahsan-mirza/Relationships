using Posts.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TestTwo_20151.Models;
using TestTwo_20151.ViewModels;

namespace TestTwo_20151.Controllers
{
    public class PictureController : Controller
    {
        private RepoMovie man = new RepoMovie();

        private RepoDirector dir = new RepoDirector();

        private RepoGenre gen = new RepoGenre();

        private RepoPicture pic = new RepoPicture();


        // GET: Picture
        public ActionResult Index()
        {
            return View("Index",pic.getAllPictures());
        }

        public ActionResult Image(int? id)
        {
            int lookup = id.GetValueOrDefault();
            var m = pic.GetPicBYId(lookup);

            if (m == null)
            {
                return HttpNotFound();
            }
            else
            {
                return File(m.Image, m.ImageType);
            }
        }

        public ActionResult Details(int? id)
        {
            return View(pic.GetPicBYId(id));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(photoAdd picture)
        {
            if (ModelState.IsValid)
            {
                pic.addPicture(picture);

              
                return View("Index",pic.getAllPictures());
            }

            return View(picture);
        }

        public ActionResult Delete(int? id)
        {
            return View(pic.GetPicBYId(id));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? id)
        {
            pic.deletePicture(id);
            return View("Index", pic.getAllPictures());
        }

    }
}