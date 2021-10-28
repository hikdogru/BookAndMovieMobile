using BookAndMovieMobile.Model.TV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookAndMovieMobile.View.Pages.TV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TVShowWishlist : ContentPage
    {
        public TVShowWishlist(List<TVShowModel> tvShows)
        {
            InitializeComponent();
            tvShowList.ItemsSource = tvShows;
        }
    }
}