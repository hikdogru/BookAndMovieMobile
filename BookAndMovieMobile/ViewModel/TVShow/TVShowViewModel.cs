using BookAndMovieMobile.Model.TMDB;
using BookAndMovieMobile.Model.TV;
using BookAndMovieMobile.View.Pages;
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
            Application.Current.MainPage.Navigation.PushModalAsync(new TVShowList(tvShows : tvShows), true);

        }
    }
}
