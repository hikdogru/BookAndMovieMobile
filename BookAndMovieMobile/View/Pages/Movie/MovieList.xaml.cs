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
    public partial class MovieList : ContentPage
    {
        public MovieList(List<MovieModel> movies, string movielistTypeName)
        {
            InitializeComponent();
            GetMovies(movies: movies, movielistTypeName: movielistTypeName);
        }

        private void GetMovies(List<MovieModel> movies, string movielistTypeName)
        {
            movieList.ItemsSource = movies;
            
        }
    }
}