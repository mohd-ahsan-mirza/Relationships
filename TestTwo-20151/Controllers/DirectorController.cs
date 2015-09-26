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
    public class DirectorController : Controller
    {
        private RepoMovie man = new RepoMovie();

        private RepoDirector dir = new RepoDirector();

        private RepoGenre gen = new RepoGenre();

        public ActionResult Index()
        {
            return View(dir.GetDirectorsForList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DirectorFull movie = dir.GetDirectorFull(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        public ActionResult Create()
        {
            DirectorAddForm directoraddform = new DirectorAddForm();
            directoraddform.Movies = man.getSelectMoviesList();

            return View(directoraddform);
        }

        [HttpPost]
        public ActionResult Create(DirectorAdd newItem)
        {
            if (newItem == null)
            {
                return HttpNotFound();
            }
            else
            {
                dir.AddDirector(newItem);
                return View("Index", dir.GetDirectorsForList());
            }
        }

        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            else
            {
                DirectorFull direct = dir.GetDirectorFull(id);

                if (direct == null)
                {
                    return View("Error");
                }

                else
                {
                    DirectorEditForm editform = dir.getDirectorEditForm(direct);

                    //editform.movie = mov;
                    editform.Movies = man.getSelectListForAddition(id);
                    
                    //
                    editform.movieRemove = man.SelectListForDeletion(id);
                    //


                    return View(editform);
                }
            }

        }


        [HttpPost]
        public ActionResult Edit(DirectorEdit newItem)
        {
            dir.EditDirector(newItem);

            return View("Index", dir.GetDirectorsForList());
        }

        public ActionResult Delete(int? id)
        {

            if (id == null)
            {
                return HttpNotFound();
            }

            return View(dir.GetDirectorFull(id));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            
            dir.DeleteDirector(id);

            return View("Index", dir.GetDirectorsForList());
        }

    }
}
