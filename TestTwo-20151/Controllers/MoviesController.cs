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
    public class MoviesController : Controller
    {
        private RepoMovie man = new RepoMovie();

        private RepoDirector dir = new RepoDirector();

        private RepoGenre gen = new RepoGenre();

        // GET: Movies
        public ActionResult Index()
        {
            return View(man.GetMoviesForList());
        }

        // GET: Movies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovieFull movie = man.GetMovieFull(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        public ActionResult Create()
        {
            MovieAddForm movieaddform = new MovieAddForm();
            movieaddform.Director = dir.getSelectDirectorsList();
            movieaddform.Genres = gen.getSelectGenresList();

            return View(movieaddform);
        }

        [HttpPost]
        public ActionResult Create(MovieAdd newItem)
        {
            if (ModelState.IsValid)
            {
                var addedItem = man.AddMovie(newItem);
                if (addedItem == null)
                {
                    return View("Error");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return View("Error");
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
                MovieFull mov = man.GetMovieFull(id);
                
                if (mov == null)
                {
                    return View("Error");
                }

                else
                {
                    MovieEditForm editform = man.getMovieEditForm(mov);

                    //editform.movie = mov;
                    editform.Director = dir.getSelectDirectorsList();

                    editform.Genres = gen.getSelectGenresListForediting(id);
                    //
                    editform.genreRemove = gen.getSelectGenresListForRemoval(id);
                    //
                   
                    
                    return View(editform);
                }
            }
        }

        //[HttpPost]
        //public ActionResult Edit(MovieAdd mov)
        //{
        //    man.EditMovie(mov);

        //    return RedirectToAction("Index");
        //}

        [HttpPost]
        public ActionResult Edit(MovieEdit mov)
        {
            

            man.EditMovie(mov);

            //return RedirectToAction("Index");

            return RedirectToAction("Details", new { Id = mov.Id });

        }

        public ActionResult Delete(int? id)
        {
            return View(man.GetMovieFull(id));
        }

        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? id)
        {
            man.DeleteMovie(id);

            return RedirectToAction("Index");

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
                man.dispose();
            }
            base.Dispose(disposing);
        }


    }
}
