using BookAndMovieMobile.Model.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookAndMovieMobile.Model.TV
{
    public class TVShowJsonModel : JsonModel
    {
        public List<TVShowModel> Results { get; set; }
    }
}
