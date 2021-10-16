using BookAndMovieMobile.Model.TMDB;
using BookAndMovieMobile.View.TabMenu;
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
    public partial class MovieDetail : ContentPage
    {
        public MovieDetail(int movieId)
        {
            InitializeComponent();
            GetMovieDetail(movieId: movieId);
            
        }

        private void GetMovieDetail(int movieId)
        {
            string clientUrl = $"https://api.themoviedb.org/3/movie/{movieId}?api_key=ebd943da4f3d062ae4451758267b1ca9&language=en-US";
            var movie = new TMDBModel().GetMovieFromTMDB(url: clientUrl);
            movieImage.Source = movie.PosterPath;
            movieOriginalTitle.Text = movie.OriginalTitle;
            movieReleaseDate.Text = movie.ReleaseDate;
            moviePopularity.Text = movie.Popularity.ToString();
            movieOverview.Text = movie.Overview;
            movieVoteAverage.Text = movie.VoteAverage.ToString();
        }
    }
}