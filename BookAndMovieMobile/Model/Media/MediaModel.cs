using System;
using System.Collections.Generic;
using System.Text;

namespace BookAndMovieMobile.Model.Media
{
    public class MediaModel
    {
        private string _rootImageUrl = "https://image.tmdb.org/t/p/w300";
        private string _posterImageUrl;
        private string _backdropImageUrl;


        public int Id { get; set; }
        public int RealId { get; set; }
        /// <summary>
        /// Media's image url
        /// </summary>
        public string? PosterPath
        {
            get => _posterImageUrl;
            set
            {
                if (value.Contains(_rootImageUrl) == false)
                    _posterImageUrl = _rootImageUrl + value;
                else
                    _posterImageUrl = value;
            }
        }
        public string OriginalLanguage { get; set; }
        public double Popularity { get; set; }
        public string BackdropPath
        {
            get => _backdropImageUrl;
            set
            {
                if (value.Contains(_rootImageUrl) == false)
                    _backdropImageUrl = _rootImageUrl + value;
                else
                    _backdropImageUrl = value;

            }
        }
        public int VoteCount { get; set; }
        public double VoteAverage { get; set; }
        public double Rating { get; set; }
        public string Overview { get; set; }
        public int DatabaseSavingType { get; set; }
    }
}
