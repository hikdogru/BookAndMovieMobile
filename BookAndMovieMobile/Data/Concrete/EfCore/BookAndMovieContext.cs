using BooksAndMovies.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAndMovieMobile.Data.Concrete.EfCore
{
    public class BookAndMovieContext: DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<TVShow> TVShows { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserMovie> UserMovies { get; set; }
        public DbSet<UserTVShow> UserTVShows { get; set; }
        public DbSet<UserBook> UserBooks { get; set; }


        public BookAndMovieContext(BookAndMovieContext context)
        {
        }

        public BookAndMovieContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=ACER;Initial Catalog=BookAndMovie;Integrated Security=True;");
        }
    }
}
