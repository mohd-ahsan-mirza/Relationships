using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestTwo_20151.Models;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace TestTwo_20151.ViewModels
{
    public class MovieForList
    {
        [Key]
        public int Id { get; set; }

        [Required, Display(Name = "Movie Title")]
        public string MovieTitle { get; set; }
    }

    /// <summary>
    /// MovieFull ViewModel to be used in Details 
    /// </summary>
    public class MovieFull : MovieForList
    {     
        public MovieFull()
        {
            this.Genres = new List<Genre>();
        }

        [Display(Name="Ticket Price")]
        public decimal TicketPrice { get; set; }

       [Display(Name="Director's Name")]
        public string DirectorName { get; set; }

        
        public List<Genre> Genres { get; set; }
    }

    public class MovieAddForm : MovieForList
    {
       
        

        
        [Required,Display(Name="Ticket Price")]
        
        public decimal TicketPrice { get; set; }


        public SelectList Director { get; set; }

        public SelectList Genres { get; set; }

    }

    public class MovieEditForm : MovieForList
    {

        [Required, Display(Name = "Ticket Price")]
        public decimal TicketPrice { get; set; }
        
        public SelectList Director { get; set; }

        public SelectList Genres { get; set; }

        //

        public SelectList genreRemove { get; set; }

        //
      
    }

    public class MovieEdit : MovieForList
    {

        [Required]
        public decimal TicketPrice { get; set; }

        public int DirectorId { get; set; }

        
        public ICollection<int> GenreId { get; set; }

        //
        public ICollection<int> genreRemoveId { get; set; }
        //
    
    }



    public class MovieAdd : MovieForList
    {

        [Required]
        public decimal TicketPrice { get; set; }

        public int DirectorId { get; set; }

        public ICollection<int> GenreId { get; set; }
    }
}