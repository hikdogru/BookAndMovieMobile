using BookAndMovieMobile.Model.TV;
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
    public partial class TVShowList : ContentPage
    {
        public TVShowList(List<TVShowModel> tvShows)
        {
            InitializeComponent();
            tvShowList.ItemsSource = tvShows;
        }
    }
}