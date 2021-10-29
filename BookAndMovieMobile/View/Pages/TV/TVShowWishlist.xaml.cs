using BookAndMovieMobile.Model.TV;
using BookAndMovieMobile.ViewModel.TVShow;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookAndMovieMobile.View.Pages.TV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TVShowWishlist : ContentPage
    {
        public  TVShowWishlist(List<TVShowModel> tvShows)
        {
            InitializeComponent();
            tvShowList.ItemsSource = tvShows;
        }
    }
}