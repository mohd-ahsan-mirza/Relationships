using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestTwo_20151.Models;

namespace TestTwo_20151.ViewModels
{
    public class RepoGenre : RepositoryBase
    {
        /// <summary>
        /// Creates List of GenreForList to be presented in the Genre List View
        /// </summary>
        /// <returns>List of GenreForList</returns>
        public IEnumerable<GenreForList> GetGenresForList()
        {
            var forList = dc.Genres.OrderBy(genre => genre.Name);

            List<GenreForList> genresForList = new List<GenreForList>();

            foreach (Genre g in forList)
            {
                GenreForList gfl = new GenreForList();
                gfl.Id = g.Id;
                gfl.Name = g.Name;
                genresForList.Add(gfl);
            }

            return genresForList;
        }


        public GenreFull getGenreFull(int? id)
        {
            return Mapper.Map<GenreFull>(dc.Genres.Include("Movies").FirstOrDefault(m => m.Id == id));
        }

        public GenreEditForm getGenreEditForm(GenreFull genre)
        {
            GenreEditForm editform = new GenreEditForm();
            editform.Id = genre.Id;
            editform.Name = genre.Name;

            return editform;
        }

        public void EditGenre(GenreEdit newItem)
        {

            Genre genre = dc.Genres.Include("Movies").FirstOrDefault(m => m.Id == newItem.Id);

            genre.Name = newItem.Name;


            try
            {

                if (newItem.movieRemoveId.Count != 0)
                {
                    foreach (var item in newItem.movieRemoveId)
                    {
                        genre.Movies.Remove(dc.Movies.Find(item));
                        //Addition to remove director from movie
                        dc.Movies.Find(item).Genres.Remove(dc.Genres.Find(newItem.Id));
                        dc.SaveChanges();
                    }



                }

            }
            catch (System.NullReferenceException)
            {

            }

            try
            {
                if (newItem.MovieId.Count != 0)
                {
                    foreach (var item in newItem.MovieId)
                    {
                        genre.Movies.Add(dc.Movies.Find(item));

                        dc.Movies.Find(item).Genres.Add(dc.Genres.Find(newItem.Id));
                        dc.SaveChanges();
                    }
                }

            }
            catch (System.NullReferenceException)
            {

            }

            dc.Entry(genre).State = EntityState.Modified;
            dc.SaveChanges();
        }


        public void DeleteGenre(int? id)
        {
            if (dc.Genres.Include("Movies").FirstOrDefault(m => m.Id == id).Movies.ToList().Count != 0)
            {
                foreach (var item in dc.Genres.Include("Movies").FirstOrDefault(m => m.Id == id).Movies.ToList())
                {
                    //dc.Movies.Remove(item);
                    //dc.SaveChanges();

                    Movie mov = dc.Movies.Find(item.Id);

                    mov.Genres.Remove(dc.Genres.Find(id));

                    dc.Entry(mov).State = EntityState.Modified;
                    dc.SaveChanges();


                }
            }

            dc.Genres.Remove(dc.Genres.Find(id));

            dc.SaveChanges();


        }



        public Genre AddGenre(GenreAdd newItem)
        {
            Genre genre = Mapper.Map<Genre>(newItem);

            try
            {
                if (newItem.MovieId.Count != 0)
                {
                    foreach (var item in newItem.MovieId.ToList())
                    {
                        genre.Movies.Add(dc.Movies.Find(item));
                        dc.Movies.Find(item).Genres.Add(genre);
                    }

                }

                //
                dc.Genres.Add(genre);
                //
                dc.SaveChanges();
            }
            catch (System.NullReferenceException)
            {
                dc.Genres.Add(genre);
            }
            dc.SaveChanges();

            return genre;
        }

        public SelectList getSelectGenresList()
        {
            SelectList genresList = new SelectList(dc.Genres, "Id", "Name");
            return genresList;
        }

        public SelectList getSelectGenresListForediting(int? id)
        {
            List<Genre> temp = dc.Genres.ToList();

            foreach (var item in dc.Movies.Include("Genres").Include("Director").FirstOrDefault(m => m.Id == id).Genres.ToList())
            {
                temp.Remove(item);
            }
            SelectList genresList = new SelectList(temp, "Id", "Name");
            return genresList;
        }


        public SelectList getSelectGenresListForRemoval(int? id)
        {
            //List<Genre> temp = dc.Genres.ToList();

            //temp.Clear();

            //foreach (var item in dc.Movies.Include("Genres").Include("Director").FirstOrDefault(m => m.Id == id).Genres.ToList())
            //{
            //    temp.Add(item);
            //}
            SelectList genresList = new SelectList(dc.Movies.Include("Genres").Include("Director").FirstOrDefault(m => m.Id == id).Genres.ToList(), "Id", "Name");
            return genresList;
        }


        //public MultiSelectList getMultiSelectGenresList()
        //{
        //    MultiSelectList genresList = new MultiSelectList(dc.Genres, "Id", "Name");
        //    return genresList;
        //}
    }
}