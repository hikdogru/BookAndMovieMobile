using BookAndMovieMobile.Model.Movie;
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
    public partial class MovieFavouritelist : ContentPage
    {
        public MovieFavouritelist(List<MovieModel> movies)
        {
            InitializeComponent();
            movieList.ItemsSource = movies;
        }
    }
}