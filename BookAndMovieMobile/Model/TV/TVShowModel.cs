using BookAndMovieMobile.Model.Media;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookAndMovieMobile.Model.TV
{
    public class TVShowModel : MediaModel
    {
        private string _name;

        public string Name
        {
            get => _name.Length < 20 ? _name : _name.Substring(0, 20) + "...";
            set => _name = value;
        }
        public string OriginalName { get; set; }
        public string FirstAirDate { get; set; }
    }
}
