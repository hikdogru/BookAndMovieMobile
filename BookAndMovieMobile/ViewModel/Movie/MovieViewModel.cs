using BookAndMovieMobile.Model.Movie;
using BookAndMovieMobile.Model.TMDB;
using BookAndMovieMobile.View.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace BookAndMovieMobile.ViewModel.Movie
{
    public class MovieViewModel
    {
        public ObservableCollection<MovieModel> Movies { get; set; }
        public ICommand MovieDetailCommand => new Command(MovieDetail);
        

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

        private void MovieDetail(object obj)
        {
            var movie = ((MovieModel)obj);
            Application.Current.MainPage.Navigation.PushModalAsync(new MovieDetail(movieId : movie.Id), true);
        }


    }
}
