using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TestTwo_20151.Models
{
    public class DataContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public DataContext() : base("name=DataContext")
        {
        }

        public System.Data.Entity.DbSet<TestTwo_20151.Models.Movie> Movies { get; set; }

        public System.Data.Entity.DbSet<TestTwo_20151.Models.Director> Directors { get; set; }

        public System.Data.Entity.DbSet<TestTwo_20151.Models.Genre> Genres { get; set; }

        public DbSet<Picture> Pictures { get; set; }

        public System.Data.Entity.DbSet<TestTwo_20151.ViewModels.MovieAddForm> MovieAddForms { get; set; }

        public System.Data.Entity.DbSet<TestTwo_20151.ViewModels.MovieFull> MovieFulls { get; set; }

        public System.Data.Entity.DbSet<TestTwo_20151.ViewModels.MovieEditForm> MovieEditForms { get; set; }

        public System.Data.Entity.DbSet<TestTwo_20151.ViewModels.DirectorForList> DirectorForLists { get; set; }

        public System.Data.Entity.DbSet<TestTwo_20151.ViewModels.GenreForList> GenreForLists { get; set; }
    
    }
}
