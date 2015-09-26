using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestTwo_20151.ViewModels
{
    public class GenreForList
    {
        public int Id { get; set; }

        [Required, Display(Name = "Title Name")]
        public string Name { get; set; }
    }


    public class GenreAddForm : GenreForList
    {
        public SelectList Movies { get; set; }
    }

    public class GenreAdd : GenreForList
    {
        public ICollection<int> MovieId { get; set; }
    }



    public class GenreFull : GenreForList
    {
        public GenreFull()
        {
            Movies = new List<MovieForList>();
        }

        public List<MovieForList> Movies { get; set; }
    }

    public class GenreEditForm : GenreForList
    {
        public SelectList Movies { get; set; }
        public SelectList movieRemove { get; set; }
    }

    public class GenreEdit : GenreForList
    {
        public ICollection<int> MovieId { get; set; }
        public ICollection<int> movieRemoveId { get; set; }
    }
}