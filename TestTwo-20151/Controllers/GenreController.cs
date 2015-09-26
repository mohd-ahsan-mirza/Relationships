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
    public class GenreController : Controller
    {
        // GET: Genre
        private RepoMovie man = new RepoMovie();

        private RepoDirector dir = new RepoDirector();

        private RepoGenre gen = new RepoGenre();

        public ActionResult Index()
        {
            return View(gen.GetGenresForList());
        }


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GenreFull genre = gen.getGenreFull(id);
            if (genre == null)
            {
                return HttpNotFound();
            }
            return View(genre);
        }




        public ActionResult Create()
        {
            GenreAddForm directoraddform = new GenreAddForm();
            directoraddform.Movies = man.getSelectMoviesList();

            return View(directoraddform);
        }


        [HttpPost]
        public ActionResult Create(GenreAdd newItem)
        {
            if (newItem == null)
            {
                return HttpNotFound();
            }
            else
            {
                //gen.AddGenre(newItem);
                //return View("Index",gen.GetGenresForList());

                Genre genre = gen.AddGenre(newItem);

                return RedirectToAction("Details", new { Id = genre.Id });

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
                GenreFull genre = gen.getGenreFull(id);

                if (genre == null)
                {
                    return View("Error");
                }

                else
                {
                    GenreEditForm editform = gen.getGenreEditForm(genre);

                    //editform.movie = mov;
                    editform.Movies = man.getSelectListForAdditionForGenre(id);

                    //
                    editform.movieRemove = man.SelectListForDeletionForGenre(id);
                    //


                    return View(editform);
                }
            }
        }

        [HttpPost]
        public ActionResult Edit(GenreEdit newItem)
        {
            gen.EditGenre(newItem);

            return View("Index", gen.GetGenresForList());
        }

        public ActionResult Delete(int? id)
        {

            if (id == null)
            {
                return HttpNotFound();
            }

            return View(gen.getGenreFull(id));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }


            gen.DeleteGenre(id);

            return View("Index", gen.GetGenresForList());
        }

    }
}