using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Data.Entity;
using AutoMapper;
using TestTwo_20151.ViewModels;

namespace TestTwo_20151
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            Database.SetInitializer(new TestTwo_20151.Models.Initializer());

            Mapper.CreateMap<Models.Movie, ViewModels.MovieForList>();
           
            Mapper.CreateMap<Models.Movie, ViewModels.MovieFull>();

            Mapper.CreateMap<ViewModels.MovieAdd, Models.Movie>();

            Mapper.CreateMap<ViewModels.MovieFull, ViewModels.MovieEditForm>();

            Mapper.CreateMap<ViewModels.MovieAdd, ViewModels.MovieFull>();

            Mapper.CreateMap<Models.Director, ViewModels.DirectorFull>();

            Mapper.CreateMap<ViewModels.DirectorAdd, Models.Director>();

            Mapper.CreateMap<ViewModels.DirectorFull, ViewModels.DirectorEditForm>();

            Mapper.CreateMap<ViewModels.GenreAdd, Models.Genre>();

            Mapper.CreateMap<Models.Genre, ViewModels.GenreFull>();


        }
    }
}
