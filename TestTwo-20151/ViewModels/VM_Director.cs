using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestTwo_20151.ViewModels
{
    public class DirectorForList
    {
        public int Id { get; set; }

        [Required,Display(Name="Director Name")]
        public string Name { get; set; }
    }

    public class DirectorFull : DirectorForList
    {
        public DirectorFull()
        {
            Movies = new List<MovieForList>();
        }

        public List<MovieForList> Movies { get; set; }
    }

    public class DirectorAddForm : DirectorForList
    {
        public SelectList Movies { get; set; }
    }

    public class DirectorAdd : DirectorForList
    {
        public ICollection<int> MovieId { get; set; }
    }

    public class DirectorEditForm : DirectorForList
    {
        public SelectList Movies { get; set; }
        public SelectList movieRemove { get; set; }

    }

    public class DirectorEdit : DirectorForList
    {
        public ICollection<int> MovieId { get; set; }
        public ICollection<int> movieRemoveId { get; set; }
    } 
}