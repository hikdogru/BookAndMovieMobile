using BookAndMovieMobile.Model.Movie;
using BookAndMovieMobile.Model.TMDB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace BookAndMovieMobile.ViewModel.Movie
{
    public class MovieViewModel
    {
        public ObservableCollection<MovieModel> Movies { get; set; }

        public MovieViewModel()
        {
            GetPopularMovies();
        }

        private void GetPopularMovies()
        {
            Movies = new ObservableCollection<MovieModel>();
            string clientUrl = "https://api.themoviedb.org/3/movie/popular?api_key=ebd943da4f3d062ae4451758267b1ca9&language=en-US";
            var movies = new TMDBModel().GetMoviesFromTMDB(url: clientUrl);
            movies.ForEach(m => Movies.Add(m));
            //Movies.Add(movies[0]);
        }
    }
}
