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
    public partial class TVShowSearch : ContentPage
    {
        public TVShowSearch()
        {
            InitializeComponent();
        }

        private void ButtonClicked(object sender, EventArgs e)
        {
            txtSearchQuery.Text = "";
        }

        private void SearchTvShow(object sender, EventArgs e)
        {
            string clientUrl = "https://api.themoviedb.org/3/search/tv?api_key=ebd943da4f3d062ae4451758267b1ca9&language=en-US" + "&query=" + txtSearchQuery.Text;
            var model = new TMDBModel();
            var tvshows = model.GetTVShowsFromTMDB(url: clientUrl);
            tvShowList.ItemsSource = tvshows;
            txtSearchQuery.Text = "";
        }
    }
}