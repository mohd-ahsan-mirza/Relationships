using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace TestTwo_20151.Models
{
    public class Initializer : DropCreateDatabaseAlways<DataContext>
    {
        protected override void Seed(DataContext dc)
        {
            Genre g = new Genre("Fantasy");
            dc.Genres.Add(g);
            Genre g1 = new Genre("Drama");
            dc.Genres.Add(g1);
            Genre g2 = new Genre("Comedy");
            dc.Genres.Add(g2);
            Genre g3 = new Genre("Adventure");
            dc.Genres.Add(g3);
            Genre g4 = new Genre("War");
            dc.Genres.Add(g4);
            Genre g5 = new Genre("Crime");
            dc.Genres.Add(g5);

            Director d = new Director("Goldwyn");
            dc.Directors.Add(d);
            Movie mo = new Movie();
            mo.MovieTitle = "Darkfall Resurection";
            mo.TicketPrice = 15.99m;
            mo.Director = d;
            mo.Genres.Add(g);
            mo.Genres.Add(g1);


            //dc.Directors.Find(d.Id).Movies.Add(mo);
            //dc.SaveChanges();
            //dc.Genres.Find(g.Id).Movies.Add(mo);
            //dc.SaveChanges();
            //dc.Genres.Find(g1.Id).Movies.Add(mo);
            //dc.SaveChanges();

            dc.Movies.Add(mo);

            //dc.SaveChanges();

            


            mo = null;
            d = null;

            d = new Director("Hill");
            dc.Directors.Add(d);
            mo = new Movie();
            mo.MovieTitle = "The Life & Adventures of Santa Claus";
            mo.TicketPrice = 12.99m;
            mo.Director = d;
            mo.Genres.Add(g);
            mo.Genres.Add(g2);
            
            //dc.Directors.Find(d.Id).Movies.Add(mo);
            //dc.Genres.Find(g2.Id).Movies.Add(mo);
            //dc.Genres.Find(g.Id).Movies.Add(mo);
            
            dc.Movies.Add(mo);

            //dc.SaveChanges();

            mo = null;
            d = null;

            d = new Director("Lean");
            dc.Directors.Add(d);
            mo = new Movie();
            mo.MovieTitle = "Lawrence of Arabia";
            mo.TicketPrice = 14.99m;
            mo.Director = d;
            mo.Genres.Add(g4);
            mo.Genres.Add(g3);
            mo.Genres.Add(g1);
            dc.Movies.Add(mo);
            //dc.Directors.Find(d.Id).Movies.Add(mo);
            //dc.SaveChanges();
            //dc.Genres.Find(g1.Id).Movies.Add(mo);
            //dc.SaveChanges();
            //dc.Genres.Find(g3.Id).Movies.Add(mo);
            //dc.SaveChanges();
            //dc.Genres.Find(g4.Id).Movies.Add(mo);
            //dc.SaveChanges();

            mo = null;

            mo = new Movie();
            mo.MovieTitle = "A Passage to India";
            mo.TicketPrice = 16.99m;
            mo.Director = d;
            mo.Genres.Add(g1);
            mo.Genres.Add(g3);
            dc.Movies.Add(mo);
            //dc.Directors.Find(d.Id).Movies.Add(mo);
            //dc.SaveChanges();
            //dc.Genres.Find(g1.Id).Movies.Add(mo);
            //dc.SaveChanges();
            //dc.Genres.Find(g3.Id).Movies.Add(mo);
            //dc.SaveChanges();

            mo = null;
            d = null;

            d = new Director("Aldrich");
            dc.Directors.Add(d);
            mo = new Movie();
            mo.MovieTitle = "The Dirty Dozen";
            mo.TicketPrice = 15.99m;
            mo.Director = d;
            mo.Genres.Add(g4);
            mo.Genres.Add(g2);
            mo.Genres.Add(g1);
            dc.Movies.Add(mo);
            //dc.Directors.Find(d.Id).Movies.Add(mo);
            //dc.SaveChanges();
            //dc.Genres.Find(g1.Id).Movies.Add(mo);
            //dc.SaveChanges();
            //dc.Genres.Find(g2.Id).Movies.Add(mo);
            //dc.SaveChanges();
            //dc.Genres.Find(g4.Id).Movies.Add(mo);
            //dc.SaveChanges();
           
            mo = null;

            mo = new Movie();
            mo.MovieTitle = "The Choirboys";
            mo.TicketPrice = 12.99m;
            mo.Director = d;
            mo.Genres.Add(g1);
            mo.Genres.Add(g2);
            mo.Genres.Add(g5);
            dc.Movies.Add(mo);
            //dc.Directors.Find(d.Id).Movies.Add(mo);
            //dc.SaveChanges();
            //dc.Genres.Find(g1.Id).Movies.Add(mo);
            //dc.SaveChanges();
            //dc.Genres.Find(g2.Id).Movies.Add(mo);
            //dc.SaveChanges();
            //dc.Genres.Find(g5.Id).Movies.Add(mo);
            //dc.SaveChanges();



            mo = null;

            mo = new Movie();
            mo.MovieTitle = "The Longest Yard";
            mo.TicketPrice = 13.99m;
            mo.Director = d;
            mo.Genres.Add(g1);
            mo.Genres.Add(g2);
            mo.Genres.Add(g5);
            dc.Movies.Add(mo);
            //dc.Directors.Find(d.Id).Movies.Add(mo);
            //dc.SaveChanges();
            //dc.Genres.Find(g1.Id).Movies.Add(mo);
            //dc.SaveChanges();
            //dc.Genres.Find(g2.Id).Movies.Add(mo);
            //dc.SaveChanges();
            //dc.Genres.Find(g5.Id).Movies.Add(mo);
            //dc.SaveChanges();
            
            
            mo = null;
            d = null;

            d = new Director("Scott");
            dc.Directors.Add(d);
            mo = new Movie();
            mo.MovieTitle = "True Romance";
            mo.TicketPrice = 12.99m;
            mo.Director = d;
            mo.Genres.Add(g5);
            mo.Genres.Add(g1);
            dc.Movies.Add(mo);
            //dc.Directors.Find(d.Id).Movies.Add(mo);
            //dc.SaveChanges();
            //dc.Genres.Find(g1.Id).Movies.Add(mo);
            //dc.SaveChanges();
            //dc.Genres.Find(g5.Id).Movies.Add(mo);
            //dc.SaveChanges();


            mo = null;

            mo = new Movie();
            mo.MovieTitle = "Unstoppable";
            mo.TicketPrice = 12.99m;
            mo.Director = d;
            mo.Genres.Add(g3);
            mo.Genres.Add(g1);
            dc.Movies.Add(mo);
           //dc.Directors.Find(d.Id).Movies.Add(mo);
           //dc.SaveChanges();
           //dc.Genres.Find(g1.Id).Movies.Add(mo);
           //dc.SaveChanges();
           //dc.Genres.Find(g3.Id).Movies.Add(mo);
           //dc.SaveChanges();


            Picture p = new Picture()
            {
                Name = "Nature",
               
                ImageType = "image/jpg",
                Image = this.GetImage("Nature.jpg")
            };



            dc.Pictures.Add(p);

            p = null;


            p = new Picture()
            {
                Name = "Love",

                ImageType = "image/jpg",
                Image = this.GetImage("Love.jpg")
            };

            dc.Pictures.Add(p);

            p = null;


            p = new Picture()
            {
                Name = "Cake",

                ImageType = "image/jpg",
                Image = this.GetImage("Cake.jpg")
            };

            dc.Pictures.Add(p);

            p = null;


            p = new Picture()
            {
                Name = "Peace",

                ImageType = "image/jpg",
                Image = this.GetImage("Peace.jpg")
            };


            dc.Pictures.Add(p);

            p = null;

            dc.SaveChanges();
        }

        protected byte[] GetImage(string i)
        {
            string imageFile = string.Format("/App_Data/Images/{0}", i);
            return System.IO.File.ReadAllBytes(HttpContext.Current.Server.MapPath(imageFile));
        }
    }
}