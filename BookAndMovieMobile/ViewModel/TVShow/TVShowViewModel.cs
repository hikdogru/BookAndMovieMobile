using BookAndMovieMobile.Model.TMDB;
using BookAndMovieMobile.Model.TV;
using BookAndMovieMobile.View.Pages;
using BookAndMovieMobile.View.Pages.TV;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace BookAndMovieMobile.ViewModel.TVShow
{
    public class TVShowViewModel
    {
        private readonly string _rootUrl = "https://api.themoviedb.org/3/";
        public ObservableCollection<TVShowModel> TVShows { get; set; }
        public ObservableCollection<TVShowModel> SearchTVShowResults { get; set; }
        public ICommand TVShowDetailCommand => new Command(TVShowDetail);
        public ICommand TVShowSearchCommand => new Command(RedirectToTVShowSearchPage);
        public ICommand SearchCommand => new Command(Search);
        public ICommand AddTVShowWishListCommand => new Command(AddTVShowToWishlist);
        public ICommand AddTVShowWatchedListCommand => new Command(AddTVShowToWatchedList);
        public ICommand AddTVShowFavouritelistCommand => new Command(AddTVShowFavouritelist);
        public ICommand MoveTVShowWatchedlistCommand => new Command(MoveTVShowWatchedlist);


        public ICommand GetTVShowWishlistCommand => new Command(GetTVShowWishlist);
        public ICommand DeleteTVShowWishlistCommand => new Command(DeleteTVShowWishlist);

        public ICommand GetTVShowWatchedlistCommand => new Command(GetTVShowWatchedlist);
        public ICommand DeleteTVShowWatchedlistCommand => new Command(DeleteTVShowWatchedlist);
        public ICommand GetTVShowFavouritelistCommand => new Command(GetTVShowFavouritelist);
        public ICommand DeleteTVShowFavouritelistCommand => new Command(DeleteTVShowFavouritelist);




        public string SearchQuery { get; set; }

        public TVShowViewModel()
        {
            GetPopularTVShows();
        }

        private void GetPopularTVShows()
        {
            TVShows = new ObservableCollection<TVShowModel>();
            string clientUrl = _rootUrl + "tv/popular?api_key=ebd943da4f3d062ae4451758267b1ca9&language=en-US";
            var tvShows = new TMDBModel().GetTVShowsFromTMDB(url: clientUrl);
            tvShows.ForEach(m => TVShows.Add(m));
        }

        private void TVShowDetail(object obj)
        {
            var tvShow = ((TVShowModel)obj);
            Application.Current.MainPage.Navigation.PushModalAsync(new TVShowDetail(tvShowId: tvShow.Id), true);
        }

        private void RedirectToTVShowSearchPage(object obj)
        {
            Application.Current.MainPage.Navigation.PushModalAsync(new TVShowSearch(), true);
        }

        private void Search(object obj)
        {
            string query = SearchQuery;
            string clientUrl = _rootUrl + $"search/tv?api_key=ebd943da4f3d062ae4451758267b1ca9&language=en-US&query={query}";
            var tvShows = new TMDBModel().GetTVShowsFromTMDB(url: clientUrl);
            Application.Current.MainPage.Navigation.PushModalAsync(new TVShowList(tvShows: tvShows), true);

        }

        private void AddTVShowToWishlist(object obj)
        {
            var tvShow = ((TVShowModel)obj);
            int id = tvShow.Id;
            var model = new TMDBModel();
            model.PostContentToTMDB(medialistId: 7111981, mediaId: id, "tv", method: Method.POST);

        }

        private void AddTVShowToWatchedList(object obj)
        {
            var tvShow = ((TVShowModel)obj);
            int id = tvShow.Id;
            var model = new TMDBModel();
            model.PostContentToTMDB(medialistId: 7111916, mediaId: id, "tv", method: Method.POST);
        }

        private void AddTVShowFavouritelist(object obj)
        {
            var tvShow = ((TVShowModel)obj);
            int id = tvShow.Id;
            var model = new TMDBModel();
            model.PostContentToTMDB(medialistId: 7111919, mediaId: id, "tv", method: Method.POST);
        }

        private void MoveTVShowWatchedlist(object obj)
        {
            var tvShow = ((TVShowModel)obj);
            int id = tvShow.Id;
            var model = new TMDBModel();
            model.PostContentToTMDB(medialistId: 7111981, mediaId: id, "tv", method: Method.DELETE);
            model.PostContentToTMDB(medialistId: 7111916, mediaId: id, "tv", method: Method.POST);
        }

        private void GetTVShowWishlist(object obj)
        {
            string clientUrl = _rootUrl + "list/7111981?api_key=ebd943da4f3d062ae4451758267b1ca9&language=en-US";
            var model = new TMDBModel();
            var tvshowWishlist = model.GetTVShowsFromTMDB(url: clientUrl);
            Application.Current.MainPage.Navigation.PushModalAsync(new TVShowWishlist(tvShows: tvshowWishlist), true);
        }

        private void GetTVShowWatchedlist(object obj)
        {
            string clientUrl = _rootUrl + "list/7111916?api_key=ebd943da4f3d062ae4451758267b1ca9&language=en-US";
            var model = new TMDBModel();
            var tvshowWishlist = model.GetTVShowsFromTMDB(url: clientUrl);
            Application.Current.MainPage.Navigation.PushModalAsync(new TVShowWatchedlist(tvShows: tvshowWishlist), true);
        }

        private void GetTVShowFavouritelist(object obj)
        {
            string clientUrl = _rootUrl + "list/7111919?api_key=ebd943da4f3d062ae4451758267b1ca9&language=en-US";
            var model = new TMDBModel();
            var tvshowFavouritelist = model.GetTVShowsFromTMDB(url: clientUrl);
            Application.Current.MainPage.Navigation.PushModalAsync(new TVShowFavouritelist(tvShows: tvshowFavouritelist), true);

        }

        private void DeleteTVShowWishlist(object obj)
        {
            var tvShow = ((TVShowModel)obj);
            int id = tvShow.Id;
            var model = new TMDBModel();
            model.PostContentToTMDB(medialistId: 7111981, mediaId: id, "tv", method: Method.DELETE);
        }

        private void DeleteTVShowWatchedlist(object obj)
        {
            var tvShow = ((TVShowModel)obj);
            int id = tvShow.Id;
            var model = new TMDBModel();
            model.PostContentToTMDB(medialistId: 7111916, mediaId: id, "tv", method: Method.DELETE);
        }

        private void DeleteTVShowFavouritelist(object obj)
        {
            var tvShow = ((TVShowModel)obj);
            int id = tvShow.Id;
            var model = new TMDBModel();
            model.PostContentToTMDB(medialistId: 7111919, mediaId: id, "tv", method: Method.DELETE);
        }
    }
}
