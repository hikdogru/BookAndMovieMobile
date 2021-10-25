﻿using BookAndMovieMobile.Data.Concrete.EfCore;
using BooksAndMovies.Data.Abstract;
using BooksAndMovies.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksAndMovies.Data.Concrete.Ef
{
    public class EfCoreMovieRepository : EfCoreEntityRepositoryBase<Movie, BookAndMovieContext> , IMovieRepository
    {
        public EfCoreMovieRepository(BookAndMovieContext context) : base(context : context)
        {
        }
    }
}