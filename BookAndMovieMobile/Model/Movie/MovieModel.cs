using BookAndMovieMobile.Model.Media;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookAndMovieMobile.Model.Movie
{
    public class MovieModel : MediaModel
    {
        private string _title = "";
        public string ReleaseDate { get; set; }
        public string Title
        {
            get => _title.Length < 20 ? _title : _title.Substring(0, 20) + "...";
            set => _title = value;
        }
        public string OriginalTitle { get; set; }
    }
}
