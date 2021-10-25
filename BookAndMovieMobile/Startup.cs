using BookAndMovieMobile.Business.Abstract;
using BookAndMovieMobile.Data.Concrete.EfCore;
using BooksAndMovies.Business.Concrete;
using BooksAndMovies.Data.Abstract;
using BooksAndMovies.Data.Concrete.Ef;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookAndMovieMobile
{
    public static class Startup
    {
        public static IServiceProvider ServiceProvider { get; set; }
        public static IServiceProvider Init()
        {
            var serviceProvider = new ServiceCollection()
                .AddDbContext<BookAndMovieContext>(option => option.UseSqlServer("Data Source=Acer;Initial Catalog=BookAndMovie;Integrated Security=True;")).BuildServiceProvider();
            ServiceProvider = serviceProvider;
            return ServiceProvider;

        }
    }
}
