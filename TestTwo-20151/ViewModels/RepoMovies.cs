using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestTwo_20151.Models;
using AutoMapper;
using System.Data.Entity;


namespace TestTwo_20151.ViewModels
{
    public class RepoMovie : RepositoryBase
    {
        /// <summary>
        /// Creates List of MovieForList to be presented in the Movie List View
        /// </summary>
        /// <returns>List of MovieForList</returns>
        public IEnumerable<MovieForList> GetMoviesForList()
        {
            var forList = dc.Movies.OrderBy(movie => movie.MovieTitle);


            //List<MovieForList> moviesForList = new List<MovieForList>();

            //foreach (Movie m in forList)
            //{
            //    MovieForList mfl = new MovieForList();
            //    mfl.Id = m.Id;
            //    mfl.Title = m.MovieTitle;
            //    moviesForList.Add(mfl);
            //}

            //return moviesForList;

            return Mapper.Map<IEnumerable<MovieForList>>(forList);


        }

        public SelectList getSelectMoviesList()
        {
            SelectList directorsList = new SelectList(dc.Movies, "Id", "MovieTitle");
            return directorsList;
        }


        /// <summary>
        /// Creates a MovieFull object based on provided Id
        /// </summary>
        /// <param name="id">Movie Id</param>
        /// <returns>MovieFull object based on id</returns>
        public MovieFull GetMovieFull(int? id)
        {

            Movie movie = dc.Movies.Include("Genres").Include("Director").FirstOrDefault(m => m.Id == id);



            //MovieFull mf = new MovieFull();

            //mf.Id = movie.Id;
            //mf.TicketPrice = movie.TicketPrice;
            //mf.MovieTitle = movie.MovieTitle;
            //mf.DirectorName = movie.Director.Name;
            //foreach (var item in movie.Genres)
            //{
            //    mf.Genres.Add(item.Name);
            //}

            //return mf;


            return Mapper.Map<MovieFull>(movie);
        }

        public Movie AddMovie(MovieAdd newItem)
        {
            Movie movie = Mapper.Map<Movie>(newItem);

            movie.Director = dc.Directors.Find(newItem.DirectorId);


            try
            {
                foreach (var item in newItem.GenreId.ToList())
                {
                    movie.Genres.Add(dc.Genres.Find(item));
                }
            }

            catch (System.ArgumentNullException)
            {

            }

            dc.Movies.Add(movie);

            dc.Directors.Find(newItem.DirectorId).Movies.Add(movie);

            try
            {

                foreach (var item in newItem.GenreId.ToList())
                {
                    dc.Genres.Find(item).Movies.Add(movie);
                }
            }

            catch (System.ArgumentNullException)
            {

            }
            dc.SaveChanges();

            return movie;
        }

        public MovieEditForm getMovieEditForm(MovieFull mov)
        {
            MovieEditForm movieedit = new MovieEditForm();

            movieedit.Id = mov.Id;
            movieedit.MovieTitle = mov.MovieTitle;
            movieedit.TicketPrice = mov.TicketPrice;

            return movieedit;
        }

        public SelectList getSelectListForAddition(int? id)
        {
            List<Movie> temp = dc.Movies.ToList();

            foreach (var item in dc.Directors.Include("Movies").FirstOrDefault(m => m.Id == id).Movies.ToList())
            {
                temp.Remove(item);
            }
            SelectList genresList = new SelectList(temp, "Id", "MovieTitle");
            return genresList;

           
        }

        public SelectList getSelectListForAdditionForGenre(int? id)
        {
            List<Movie> temp = dc.Movies.ToList();

            foreach (var item in dc.Genres.Include("Movies").FirstOrDefault(m => m.Id == id).Movies.ToList())
            {
                temp.Remove(item);
            }
            SelectList genresList = new SelectList(temp, "Id", "MovieTitle");
            return genresList;
        }



        public SelectList SelectListForDeletion(int?id)
        {
            return (new SelectList(dc.Directors.Include("Movies").FirstOrDefault(m => m.Id==id).Movies.ToList(),"Id","MovieTitle"));
        }

        public SelectList SelectListForDeletionForGenre(int? id)
        {
            return (new SelectList(dc.Genres.Include("Movies").FirstOrDefault(m => m.Id == id).Movies.ToList(), "Id", "MovieTitle"));
        }


        public void DeleteMovie(int? id)
        {
            foreach(var item in dc.Movies.Find(id).Genres.ToList())
            {
                dc.Genres.Find(item.Id).Movies.Remove(dc.Movies.Find(id));
            }

            //int iden = dc.Movies.Find(id).Director.Id;

            //dc.Directors.Find(iden).Movies.Remove(dc.Movies.Find(id));
            dc.Movies.Remove(dc.Movies.Find(id));

            dc.SaveChanges();
        }

        public void dispose()
        {
            dc.Dispose();
        }



        public void EditMovie(MovieEdit newItem)
        {
           

            var itemToEdit = dc.Movies.Include("Genres").Include("Director").FirstOrDefault( m=> m.Id==newItem.Id);

            itemToEdit.Id = newItem.Id;

            itemToEdit.MovieTitle = newItem.MovieTitle;

            itemToEdit.TicketPrice = newItem.TicketPrice;

            //Director dirPrevious = dc.Directors.Find(newItem.Id);

            //itemToEdit.Director = dc.Directors.Find(newItem.DirectorId);

            //if (!(dirPrevious.Id == newItem.DirectorId))
            //    dc.Directors.Find(newItem.DirectorId).Movies.Add(itemToEdit);
            //else
            //{
            //    dc.Directors.Find(newItem.DirectorId).Movies.Remove(itemToEdit);
            //}

            if (!(dc.Directors.Find(newItem.DirectorId).Movies.Contains(itemToEdit)))
                dc.Directors.Find(newItem.DirectorId).Movies.Add(itemToEdit);
            else
            {
                dc.Directors.Find(newItem.DirectorId).Movies.Remove(itemToEdit);
            }

            

            try
            {

                if (newItem.genreRemoveId.ToList().Count != 0)
                {
                    foreach (var item in newItem.genreRemoveId.ToList())
                    {


                        itemToEdit.Genres.Remove(dc.Genres.Find(item));
                        dc.Genres.Find(item).Movies.Remove(dc.Movies.Find(itemToEdit.Id));
                        dc.SaveChanges();
                    }
                }
            }
            catch (System.ArgumentNullException)
            {

            }

            try
            {
                if (newItem.GenreId.ToList().Count != 0)
                {

                    foreach (var item in newItem.GenreId.ToList())
                    {

                        itemToEdit.Genres.Add(dc.Genres.Find(item));
                        dc.Genres.Find(item).Movies.Add(dc.Movies.Find(newItem.Id));
                        dc.SaveChanges();

                    }

                }
            }

            catch (System.ArgumentNullException)
            {

            }

            
            //dc.Entry(dc.Movies.Find(newItem.Id)).CurrentValues.SetValues(itemToEdit);
            dc.Entry(itemToEdit).State = EntityState.Modified;
                dc.SaveChanges();
           

            
        }
        
    }
}