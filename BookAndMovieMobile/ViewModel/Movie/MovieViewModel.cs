using BookAndMovieMobile.Model.Movie;
using BookAndMovieMobile.Model.TMDB;
using BookAndMovieMobile.View.Pages;
using RestSharp;
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
        private readonly string _rootUrl = "https://api.themoviedb.org/3/";
        public ObservableCollection<MovieModel> Movies { get; set; }
        public string SearchQuery { get; set; }
        public ICommand MovieDetailCommand => new Command(MovieDetail);
        public ICommand MovieSearchCommand => new Command(RedirectToMovieSearchPage);
        public ICommand SearchCommand => new Command(Search);
        public ICommand MovieWishListCommand => new Command(AddMovieToWishlist);
        public ICommand MovieWatchedListCommand => new Command(AddMovieToWatchedList);
        public ICommand AddMovieFavouritelistCommand => new Command(AddMovieToFavouritelist);
        public ICommand MoveMovieWatchedlistCommand => new Command(MoveMovieWatchedlist);

        public ICommand GetMovieWishlistCommand => new Command(GetMovieWishlist);
        public ICommand DeleteMovieWishlistCommand => new Command(DeleteMovieWishlist);

        public ICommand GetMovieWatchedlistCommand => new Command(GetMovieWatchedlist);
        public ICommand DeleteMovieWatchedlistCommand => new Command(DeleteMovieWatchedlist);

        public ICommand GetMovieFavouritelistCommand => new Command(GetMovieFavouritelist);
        public ICommand DeleteMovieFavouritelistCommand => new Command(DeleteMovieFavouritelist);

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
        }

        private void MovieDetail(object obj)
        {
            var movie = ((MovieModel)obj);
            Application.Current.MainPage.Navigation.PushModalAsync(new MovieDetail(movieId: movie.Id), true);
        }

        private void RedirectToMovieSearchPage(object obj)
        {
            Application.Current.MainPage.Navigation.PushModalAsync(new MovieSearch(), true);

        }

        private void Search(object obj)
        {
            string query = SearchQuery;
            string clientUrl = _rootUrl + $"search/movie?api_key=ebd943da4f3d062ae4451758267b1ca9&language=en-US&query={query}";
            var movies = new TMDBModel().GetMoviesFromTMDB(url: clientUrl);
            Application.Current.MainPage.Navigation.PushModalAsync(new MovieList(movies: movies, movielistTypeName: "search"), true);
        }

        private void AddMovieToWishlist(object obj)
        {
            var movie = ((MovieModel)obj);
            int id = movie.Id;
            var model = new TMDBModel();
            model.PostContentToTMDB(medialistId: 7111914, mediaId: id, "movie", method: Method.POST);
        }

        private void AddMovieToWatchedList(object obj)
        {
            var movie = ((MovieModel)obj);
            int id = movie.Id;
            var model = new TMDBModel();
            model.PostContentToTMDB(medialistId: 7111917, mediaId: id, "movie", method: Method.POST);
        }

        private void AddMovieToFavouritelist(object obj)
        {
            var movie = ((MovieModel)obj);
            int id = movie.Id;
            var model = new TMDBModel();
            model.PostContentToTMDB(medialistId: 7111920, mediaId: id, "movie", method: Method.POST);
        }

        private void MoveMovieWatchedlist(object obj)
        {
            var movie = ((MovieModel)obj);
            int id = movie.Id;
            var model = new TMDBModel();
            model.PostContentToTMDB(medialistId: 7111914, mediaId: id, "movie", method: Method.DELETE);
            model.PostContentToTMDB(medialistId: 7111917, mediaId: id, "movie", method: Method.POST);
        }

        private void GetMovieWishlist(object obj)
        {
            string clientUrl = _rootUrl + "list/7111914?api_key=ebd943da4f3d062ae4451758267b1ca9&language=en-US";
            var model = new TMDBModel();
            var movieWishlist = model.GetMoviesFromTMDB(url: clientUrl);
            Application.Current.MainPage.Navigation.PushModalAsync(new MovieWishlist(movies: movieWishlist), true);
        }

        private void GetMovieWatchedlist(object obj)
        {
            string clientUrl = _rootUrl + "list/7111917?api_key=ebd943da4f3d062ae4451758267b1ca9&language=en-US";
            var model = new TMDBModel();
            var movieWatchedlist = model.GetMoviesFromTMDB(url: clientUrl);
            Application.Current.MainPage.Navigation.PushModalAsync(new MovieWatchedlist(movies: movieWatchedlist), true);
        }
        private void GetMovieFavouritelist(object obj)
        {
            string clientUrl = _rootUrl + "list/7111920?api_key=ebd943da4f3d062ae4451758267b1ca9&language=en-US";
            var model = new TMDBModel();
            var movieFavouritelist = model.GetMoviesFromTMDB(url: clientUrl);
            Application.Current.MainPage.Navigation.PushModalAsync(new MovieFavouritelist(movies: movieFavouritelist), true);
        }

        private void DeleteMovieWishlist(object obj)
        {
            var movie = ((MovieModel)obj);
            int id = movie.Id;
            var model = new TMDBModel();
            model.PostContentToTMDB(medialistId: 7111914, mediaId: id, "movie", method: Method.DELETE);
        }
        
        private void DeleteMovieWatchedlist(object obj)
        {
            var movie = ((MovieModel)obj);
            int id = movie.Id;
            var model = new TMDBModel();
            model.PostContentToTMDB(medialistId: 7111917, mediaId: id, "movie", method: Method.DELETE);
        }

        private void DeleteMovieFavouritelist(object obj)
        {
            var movie = ((MovieModel)obj);
            int id = movie.Id;
            var model = new TMDBModel();
            model.PostContentToTMDB(medialistId: 7111920, mediaId: id, "movie", method: Method.DELETE);
        }

    }
}
