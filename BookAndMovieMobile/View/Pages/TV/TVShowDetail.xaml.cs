using BookAndMovieMobile.Model.TMDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookAndMovieMobile.View.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TVShowDetail : ContentPage
    {
        public TVShowDetail(int tvShowId)
        {
            InitializeComponent();
            GetTVShowDetail(tvShowId: tvShowId);

        }

        private void GetTVShowDetail(int tvShowId)
        {
            string clientUrl = $"https://api.themoviedb.org/3/tv/{tvShowId}?api_key=ebd943da4f3d062ae4451758267b1ca9&language=en-US";
            var tvShow = new TMDBModel().GetTVShowFromTMDB(url: clientUrl);
            tvShowImage.Source = tvShow.PosterPath;
            tvShowOriginalTitle.Text = tvShow.OriginalName;
            tvShowReleaseDate.Text = tvShow.FirstAirDate;
            tvShowPopularity.Text = tvShow.Popularity.ToString();
            tvShowOverview.Text = tvShow.Overview;
            tvShowVoteAverage.Text = tvShow.VoteAverage.ToString();
            
        }


    }
}