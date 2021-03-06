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
    public partial class MovieWatchedlist : ContentPage
    {
        public MovieWatchedlist(List<MovieModel> movies)
        {
            InitializeComponent();
            movieList.ItemsSource = movies;
        }
    }
}