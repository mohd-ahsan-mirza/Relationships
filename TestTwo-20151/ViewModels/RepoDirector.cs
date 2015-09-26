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
    public class RepoDirector : RepositoryBase
    {
        /// <summary>
        /// Creates List of DirectorForList to be presented in the Director List View
        /// </summary>
        /// <returns>List of DirectorForList</returns>
        public IEnumerable<DirectorForList> GetDirectorsForList()
        {
            var forList = dc.Directors.OrderBy(director => director.Name);

            List<DirectorForList> directorsForList = new List<DirectorForList>();

            foreach (Director d in forList)
            {
                DirectorForList dfl = new DirectorForList();
                dfl.Id = d.Id;
                dfl.Name = d.Name;
                directorsForList.Add(dfl);
            }

            return directorsForList;
        }

        public SelectList getSelectDirectorsList()
        {
            SelectList directorsList = new SelectList(dc.Directors, "Id", "Name");
            return directorsList;
        }

       
        

        public DirectorFull GetDirectorFull(int? id)
        {
            return Mapper.Map<DirectorFull>(dc.Directors.Include("Movies").FirstOrDefault(m => m.Id == id));
        }

        public void AddDirector(DirectorAdd newItem)
        {
            Director director = Mapper.Map<Director>(newItem);

            try
            {
                if (newItem.MovieId.Count != 0)
                {
                    foreach (var item in newItem.MovieId.ToList())
                    {
                        director.Movies.Add(dc.Movies.Find(item));
                        dc.Movies.Find(item).Director = director;
                    }

                }

                //
                dc.Directors.Add(director);
                //
                dc.SaveChanges();
            }
            catch (System.NullReferenceException)
            {
                dc.Directors.Add(director);
            }
            dc.SaveChanges();
        }

        public DirectorEditForm getDirectorEditForm(DirectorFull direct)
        {

            DirectorEditForm editform = new DirectorEditForm();
            editform.Id = direct.Id;
            editform.Name = direct.Name;

            return editform;

        }

        public void EditDirector(DirectorEdit newItem)
        {
            Director director = dc.Directors.Include("Movies").FirstOrDefault(m => m.Id == newItem.Id);

            director.Name = newItem.Name;


            try
            {

                if (newItem.movieRemoveId.Count != 0)
                {
                    foreach (var item in newItem.movieRemoveId)
                    {
                        director.Movies.Remove(dc.Movies.Find(item));
                        //Addition to remove director from movie
                        dc.Movies.Find(item).Director = null;
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
                        director.Movies.Add(dc.Movies.Find(item));
                        
                        dc.Movies.Find(item).Director = director;
                        dc.SaveChanges();
                    }
                }

            }
            catch (System.NullReferenceException)
            {

            }

            dc.Entry(director).State = EntityState.Modified;
            dc.SaveChanges();


        }

        public void DeleteDirector(int? id)
        {

            if (dc.Directors.Include("Movies").FirstOrDefault(m => m.Id == id).Movies.ToList().Count != 0)
            {
                foreach (var item in dc.Directors.Include("Movies").FirstOrDefault(m=>m.Id==id).Movies.ToList())
                {
                    dc.Movies.Remove(item);
                    dc.SaveChanges();

                    //Movie mov = dc.Movies.Find(item.Id);

                    //mov.Director = null;

                    //dc.Entry(mov).State = EntityState.Modified;
                    //dc.SaveChanges();


                }
            }

            

            dc.Directors.Remove(dc.Directors.Find(id));

            dc.SaveChanges();



        }


    }
}