using BookAndMovieMobile.Model.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookAndMovieMobile.Model.Movie
{
    public class MovieJsonModel : JsonModel
    {
        public List<MovieModel> Results { get; set; }
        public List<MovieModel> Items { get; set; }
    }
}
